using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto4.Alumnos
{
    public partial class Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GVAlumnosEdoMunLoc_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            string nom, apem, apep, tele, correo;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                nom = e.Row.Cells[2].Text;
                apem = e.Row.Cells[3].Text;
                apep = e.Row.Cells[4].Text;
                tele = e.Row.Cells[5].Text;
                correo = e.Row.Cells[6].Text;

                e.Row.Cells[2].Text = Desencriptar(nom);
                e.Row.Cells[3].Text = Desencriptar(apem);
                e.Row.Cells[4].Text = Desencriptar(apep);
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

        protected void GVAlumnosEdoMunLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtMat.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[1].Text.ToString();
            TxtNom.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[2].Text.ToString();
            TxtApeP.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[3].Text.ToString();
            TxtApeM.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[4].Text.ToString();
            TxtTel.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[5].Text.ToString();
            TxtCorreo.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[6].Text.ToString();

            DDEstado.SelectedItem.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[7].Text.ToString();
            DDMunicipio.SelectedItem.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[8].Text.ToString();
            DDLocalidad.SelectedItem.Text = GVAlumnosEdoMunLoc.SelectedRow.Cells[9].Text.ToString();


            SqlDataSourceEstado.SelectCommand = "ConsultaEstado";
            SqlDataSourceMunicipio.SelectCommand = "ConsultaMunicipios";
            SqlDataSourceLocalidad.SelectCommand = "ConsultaLocalidad";


            GoogleMap1.Latitude = Double.Parse(GVAlumnosEdoMunLoc.SelectedRow.Cells[10].Text.ToString());
            GoogleMap1.Longitude = Double.Parse(GVAlumnosEdoMunLoc.SelectedRow.Cells[11].Text.ToString());

           
            


        }


        protected void btnInsert_Click1(object sender, EventArgs e)
        {
            string nom, apem, apep, tel, correo;

            nom = Encriptar(TxtNom.Text);
            apem = Encriptar(TxtApeM.Text);
            apep = Encriptar(TxtApeP.Text);
            tel = Encriptar(TxtTel.Text);
            correo = Encriptar(TxtCorreo.Text);

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "INSERT INTO [dbo].[Alumno]([Matricula],[Nombre],[ApePaterno],[ApeMaterno],[Telefono],[Correo],[cveEstado],[cveMunicipio],[cveLocalidad]) VALUES ('" + TxtMat.Text + "','" + nom + "','" + apep + "','" + apem + "', '" + tel + "','"+correo+"'," + DDEstado.SelectedValue.ToString() + "," + DDMunicipio.SelectedValue.ToString() + "," + DDLocalidad.SelectedValue.ToString() + ")";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtMat.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                TxtTel.Text = "";
                TxtCorreo.Text = "";
                GVAlumnosEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string nom, apem, apep, tel, correo;

            nom = Encriptar(TxtNom.Text);
            apem = Encriptar(TxtApeM.Text);
            apep = Encriptar(TxtApeP.Text);
            tel = Encriptar(TxtTel.Text);
            correo = Encriptar(TxtCorreo.Text);

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "UPDATE [dbo].[Alumno] SET [Nombre] = '" + TxtNom.Text + "',[ApePaterno] = '" + TxtApeP.Text + "',[ApeMaterno] = '" + TxtApeM.Text + "' ,[Telefono] = '" + tel + "',[Correo]='" + correo + "',[cveEstado] = " + DDEstado.SelectedValue.ToString() + ",[cveMunicipio] = " + DDMunicipio.SelectedValue.ToString() + ",[cveLocalidad] =" + DDLocalidad.SelectedValue.ToString() + "  WHERE ([Matricula] = '" + TxtMat.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtMat.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                TxtTel.Text = "";
                TxtCorreo.Text = "";
                GVAlumnosEdoMunLoc.DataBind();
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
                sql = "DELETE FROM [dbo].[Alumno] WHERE ([Matricula]='" + TxtMat.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtMat.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                GVAlumnosEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void DDEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDMunicipio.Visible = true;
            DDLocalidad.Visible = true;
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