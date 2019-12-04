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
    public partial class Directiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void GVAlumnosEdoMunLoc_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            string nom, apem, apep;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                nom = e.Row.Cells[2].Text;
                apem = e.Row.Cells[3].Text;
                apep = e.Row.Cells[4].Text;

                e.Row.Cells[2].Text = Desencriptar(nom);
                e.Row.Cells[3].Text = Desencriptar(apem);
                e.Row.Cells[4].Text = Desencriptar(apep);


            }

        }


        private string get_connectionString()
        {
            string r;
            r = @"Data Source = ;Initial Catalog=UPP;User ID=sa;Password=AAA;";
            return r;
        }

        protected void GVDirectivoEdoMunLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtNomi.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[1].Text.ToString();
            TxtNom.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[2].Text.ToString();
            TxtApeP.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[3].Text.ToString();
            TxtApeM.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[4].Text.ToString();

            DDEstado.SelectedItem.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[5].Text.ToString();
            DDMunicipio.SelectedItem.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[6].Text.ToString();
            DDLocalidad.SelectedItem.Text = GVDirectivoEdoMunLoc.SelectedRow.Cells[7].Text.ToString();


            SqlDataSourceEstado.SelectCommand = "ConsultaEstado";
            SqlDataSourceMunicipio.SelectCommand = "ConsultaMunicipios";
            SqlDataSourceLocalidad.SelectCommand = "ConsultaLocalidad";


            GoogleMap2.Latitude = Double.Parse(GVDirectivoEdoMunLoc.SelectedRow.Cells[8].Text.ToString());
            GoogleMap2.Longitude = Double.Parse(GVDirectivoEdoMunLoc.SelectedRow.Cells[9].Text.ToString());
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            EncriptarDatos();

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "INSERT INTO [dbo].[Directivo]([Nomina],[Nombre],[ApePaterno],[ApeMaterno],[cveEstado],[cveMunicipio],[cveLocalidad]) VALUES ('" + TxtNomi.Text + "','" + TxtNom.Text + "','" + TxtApeP.Text + "','" + TxtApeM.Text + "'," + DDEstado.SelectedValue.ToString() + "," + DDMunicipio.SelectedValue.ToString() + "," + DDLocalidad.SelectedValue.ToString() + ")";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                GVDirectivoEdoMunLoc.DataBind();
            }
            catch (Exception x)
            {
                Response.Write(x.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EncriptarDatos();

            try
            {
                string sql;
                SqlDataReader reader;
                SqlConnection conexion = new SqlConnection(get_connectionString());
                conexion.Open();
                sql = "UPDATE [dbo].[Directivo] SET [Nombre] = '" + TxtNom.Text + "',[ApePaterno] = '" + TxtApeP.Text + "',[ApeMaterno] = '" + TxtApeM.Text + "' ,[cveEstado] = " + DDEstado.SelectedValue.ToString() + ",[cveMunicipio] = " + DDMunicipio.SelectedValue.ToString() + ",[cveLocalidad] =" + DDLocalidad.SelectedValue.ToString() + "  WHERE ([Nomina] = '" + TxtNomi.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                GVDirectivoEdoMunLoc.DataBind();
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
                sql = "DELETE FROM [dbo].[Directivo] WHERE ([Nomina]='" + TxtNomi.Text + "')";
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = sql;
                miComando.Connection = conexion;
                reader = miComando.ExecuteReader();
                TxtNomi.Text = "";
                TxtNom.Text = "";
                TxtApeP.Text = "";
                TxtApeM.Text = "";
                GVDirectivoEdoMunLoc.DataBind();
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

        public void EncriptarDatos()
        {
            //GETTING DATA
            string nom, apem, apep;

            nom = Encriptar(TxtNom.Text);
            apem = Encriptar(TxtApeM.Text);
            apep = Encriptar(TxtApeP.Text);
        }

    }
}
