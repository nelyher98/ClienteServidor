using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Proyecto4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto4.AdmonSistema
{
    public partial class AdmonSistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BntCrearRol_Click(object sender, EventArgs e)
        {
            string CrearRol = TxtRol.Text;
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            try
            {
                if(RoleManager.RoleExists(CrearRol))
                {
                    LblRolMensage.Text ="Rol Duplicado";
                }
                else
                {
                    RoleManager.Create(new IdentityRole(CrearRol));
                    GvdRoles.DataBind();
                    TxtRol.Text = "";
                   
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void GvdRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRol.Text = GvdRoles.SelectedRow.Cells[1].Text;
        }

        protected void GvdRoles2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUser.Text = GdvRoles2.SelectedRow.Cells[1].Text;
            TxtEmail.Text = GdvRoles2.SelectedRow.Cells[3].Text;
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
           if(PwdUser1.Text == PwdUserA.Text)
            {

               var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = txtUser.Text, Email = TxtEmail.Text };
            IdentityResult result = manager.Create(user, PwdUser1.Text);
            if (result.Succeeded)
            {
                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    txtUser.Text = "";
                    TxtEmail.Text = "";
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                
            }
                

            }
        }

        protected void AsignarRol_Click(object sender, EventArgs e)
        {
            SqlDataSourceIngresarRol.InsertParameters["userid"].DefaultValue = txtUser.Text;
            SqlDataSourceIngresarRol.InsertParameters["rolid"].DefaultValue = TxtRol.Text;
            SqlDataSourceIngresarRol.Insert();
            GdvUsuariosRoles.DataBind();

        }
    }
}