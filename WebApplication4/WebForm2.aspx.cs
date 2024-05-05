using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=luzbd;User=luzgod;Password=12345;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["user"];
            string nrocuenta = Request.QueryString["nroCu"];
            string opcion = Request.QueryString["opcion"];
            if (!IsPostBack)
            {
                if (opcion == "insertar")
                {
                    infoCrear(nrocuenta);
                }
                else
                {
                    infoEditar(nrocuenta);
                }
            }          

        }


        public void infoEditar(string id)
        {
            con.Open();

            string llenar = "SELECT * FROM cuentas WHERE nro_cuenta = @id;";

            MySqlCommand com = new MySqlCommand(llenar, con);
            com.Parameters.AddWithValue("@id", id);


            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            string nro_cuenta = reader["nro_cuenta"].ToString();
            string monto_cuenta = reader["monto_cuenta"].ToString();
            string tipo_cuenta = reader["tipo_cuenta"].ToString();
            string tasainteres_cuenta = reader["tasainteres_cuenta"].ToString();
            string estado_cuenta = reader["estado_cuenta"].ToString();
            string id_usuario = reader["id_usuario"].ToString();

            Text1.Text = nro_cuenta;
            Text1.ReadOnly = true;
            Text2.Text = monto_cuenta;
            Text3.Text = tipo_cuenta;
            Text4.Text = tasainteres_cuenta;
            Text5.Text = estado_cuenta;
            Text5.ReadOnly = true;
            Text6.Text = id_usuario;
            Text6.ReadOnly = true;

            con.Close();
        }

        public void infoCrear(string id)
        {
            con.Open();

            string llenar = "SELECT * FROM cuentas WHERE nro_cuenta = @id;";

            MySqlCommand com = new MySqlCommand(llenar, con);
            com.Parameters.AddWithValue("@id", id);


            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            string tipo_cuenta = reader["tipo_cuenta"].ToString();
            string tasainteres_cuenta = reader["tasainteres_cuenta"].ToString();
            string id_usuario = reader["id_usuario"].ToString();

            Text1.Text = "NULL";
            Text1.ReadOnly = true;
            Text2.Text = "0";
            Text3.Text = tipo_cuenta;
            Text4.Text = tasainteres_cuenta;
            Text5.Text = "DISPONIBLE";
            Text5.ReadOnly = true;
            Text6.Text = id_usuario;
            Text6.ReadOnly = true;

            con.Close();
        }


        public void editar(string id)
        {
            try
            {
                int nroCuenta = int.Parse(Text1.Text);
                double montoCuenta = double.Parse(Text2.Text);
                string tipoCuenta = Text3.Text;
                string tasaCuenta = Text4.Text;
                string estadoCuenta = Text5.Text;
                int idusuario = int.Parse(Text6.Text);

                con.Open();
                MySqlCommand com = new MySqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE cuentas SET nro_cuenta=@nroCuenta, monto_cuenta=@montoCuenta, tipo_cuenta=@tipoCuenta, tasainteres_cuenta=@tasaCuenta, estado_cuenta=@estadoCuenta, id_usuario=@idusuario WHERE nro_cuenta=@id";
                com.Parameters.AddWithValue("@nroCuenta", nroCuenta);
                com.Parameters.AddWithValue("@montoCuenta", montoCuenta);
                com.Parameters.AddWithValue("@tipoCuenta", tipoCuenta);
                com.Parameters.AddWithValue("@tasaCuenta", tasaCuenta);
                com.Parameters.AddWithValue("@estadoCuenta", estadoCuenta);
                com.Parameters.AddWithValue("@idusuario", idusuario);
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery(); 
                con.Close();

                string username = Request.QueryString["user"];
                Response.Redirect("WebForm1.aspx?user=" + username);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        public void crear( )
        {
            try
            {
                double montoCuenta = double.Parse(Text2.Text);
                string tipoCuenta = Text3.Text;
                string tasaCuenta = Text4.Text;
                string estadoCuenta = Text5.Text;
                int idusuario = int.Parse(Text6.Text);

                con.Open();
                MySqlCommand com = new MySqlCommand();
                com.Connection = con;
                //INSERT INTO cuentas VALUES (NULL, $monto, '$tipo', '$tasa', '$estado', $iduser)
                com.CommandText = "INSERT INTO cuentas VALUES (NULL, @montoCuenta, @tipoCuenta, @tasaCuenta, @estadoCuenta, @idusuario)";
                com.Parameters.AddWithValue("@montoCuenta", montoCuenta);
                com.Parameters.AddWithValue("@tipoCuenta", tipoCuenta);
                com.Parameters.AddWithValue("@tasaCuenta", tasaCuenta);
                com.Parameters.AddWithValue("@estadoCuenta", estadoCuenta);
                com.Parameters.AddWithValue("@idusuario", idusuario);
                com.ExecuteNonQuery();
                con.Close();


                string username = Request.QueryString["user"];
                Response.Redirect("WebForm1.aspx?user=" + username);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string opcion = Request.QueryString["opcion"];
            string nrocuenta = Request.QueryString["nroCu"];
            if (opcion == "insertar")
            {
                crear();
            }
            else
            {
                editar(nrocuenta); 
            }
            


        }
    }
}