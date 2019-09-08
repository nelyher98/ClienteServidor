using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto4.Alumnos
{
    public partial class Maestros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GVMaestrosEdoMunLoc_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            string nom, apem, apep,tele,correo;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                nom = e.Row.Cells[2].Text;
                apep = e.Row.Cells[3].Text;
                apem = e.Row.Cells[4].Text;
                tele = e.Row.Cells[5].Text;
                correo = e.Row.Cells[6].Text;

                e.Row.Cells[2].Text = Desencriptar(nom);
                e.Row.Cells[3].Text = Desencriptar(apep);
                e.Row.Cells[4].Text = Desencriptar(apem);
                e.Row.Cells[5].Text = Desencriptar(tele);
                e.Row.Cells[6].Text = Desencriptar(correo);

            }

        }

        private string get_connectionString()
        {
            string r;
            r = @"Data Source = DESKTOP-1V3E8C5\SQLEXPRESS;Initial Catalog=UPP;User ID=sa;Password=AAA;";
            return r;
        }

        protected void GVMaestrosEdoMunLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtNomi.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[1].Text.ToString();
            TxtNom.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[2].Text.ToString();
            TxtApeP.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[3].Text.ToString();
            TxtApeM.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[4].Text.ToString();
            TxtTel.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[5].Text.ToString();
            TxtCorreo.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[6].Text.ToString();

            DDEstado.SelectedItem.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[7].Text.ToString();
            DDMunicipio.SelectedItem.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[8].Text.ToString();
            DDLocalidad.SelectedItem.Text = GVMaestrosEdoMunLoc.SelectedRow.Cells[9].Text.ToString();


            SqlDataSourceEstado.SelectCommand = "ConsultaEstado";
            SqlDataSourceMunicipio.SelectCommand = "ConsultaMunicipios";
            SqlDataSourceLocalidad.SelectCommand = "ConsultaLocalidad";


            GoogleMap3.Latitude = Double.Parse(GVMaestrosEdoMunLoc.SelectedRow.Cells[10].Text.ToString());
            GoogleMap3.Longitude = Double.Parse(GVMaestrosEdoMunLoc.SelectedRow.Cells[11].Text.ToString());
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {

            //GETTING DATA
            string nom, apem, apep,tele,correo;

            nom = Encriptar(TxtNom.Text);
            apem = Encriptar(TxtApeM.Text);
            apep = Encriptar(TxtApeP.Text);
            tele = Encriptar(TxtTel.Text);
            correo = Encriptar(TxtCorreo.Text);

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "INSERT INTO [dbo].[Maestro] ([Nomina],[Nombre],[ApePaterno],[ApeMaterno],[Telefono],[Correo],[cveEstado],[cveMunicipio],[cveLocalidad]) VALUES ('" + TxtNomi.Text + "','" + nom+ "','" + apep + "','" + apem + "','"+tele+"','"+correo +"'," + DDEstado.SelectedValue.ToString() + "," + DDMunicipio.SelectedValue.ToString() + "," + DDLocalidad.SelectedValue.ToString() + ")";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                TxtTel.Text = "";
                TxtCorreo.Text = "";
                GVMaestrosEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string nom, apem, apep, tele, correo;

            nom = Encriptar(TxtNom.Text);
            apem = Encriptar(TxtApeM.Text);
            apep = Encriptar(TxtApeP.Text);
            tele = Encriptar(TxtTel.Text);
            correo = Encriptar(TxtCorreo.Text);

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "UPDATE [dbo].[Maestro] SET [Nombre] = '" + nom + "',[ApePaterno] = '" + apep + "',[ApeMaterno] = '" + apem + "',[Telefono] = '" + tele + "',[Correo]='"+correo+"' ,[cveEstado] = " + DDEstado.SelectedValue.ToString() + ",[cveMunicipio] = " + DDMunicipio.SelectedValue.ToString() + ",[cveLocalidad] =" + DDLocalidad.SelectedValue.ToString() + "  WHERE ([Nomina] = '" + TxtNomi.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                TxtTel.Text = "";
                TxtCorreo.Text = "";
                GVMaestrosEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "DELETE FROM [dbo].[Maestro] WHERE ([Nomina]='" + TxtNomi.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                TxtTel.Text = "";
                TxtCorreo.Text = "";
                GVMaestrosEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void DDEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDMunicipio.Visible = true;
            
        }

        public string Encriptar(string r)
        {
            string key = "Programacionclienteservidor";
            byte[] keyArray;
            byte[] Arregloacifrar = UTF8Encoding.UTF8.GetBytes(r);
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            keyArray = hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashMD5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;//asignar arreglo
            tdes.Mode = CipherMode.ECB;//algoritmo
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateEncryptor();
            byte[] resultado = ctransform.TransformFinalBlock(Arregloacifrar, 0, Arregloacifrar.Length);
            tdes.Clear();
            r = Convert.ToBase64String(resultado, 0, resultado.Length);
            return r;
        }

        public string Desencriptar(string r)
        {
            string key = "Programacionclienteservidor";
            byte[] keyArray;
            byte[] Arregloacifrar = Convert.FromBase64String(r);
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            keyArray = hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashMD5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;//asignar arreglo
            tdes.Mode = CipherMode.ECB;//algoritmo
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateDecryptor();
            byte[] resultado = ctransform.TransformFinalBlock(Arregloacifrar, 0, Arregloacifrar.Length);
            tdes.Clear();
            r = UTF8Encoding.UTF8.GetString(resultado);
            return r;
        }

    }
}