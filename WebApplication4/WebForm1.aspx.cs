using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm1 : Page
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=luzbd;User=luzgod;Password=12345;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["user"] != null)
                {
                   
                    string username = Request.QueryString["user"];
                    TextBox1.Text=username;
                    GridView1.DataSource = info(username);
                    GridView1.DataBind();
                }
            }



        }

        public DataTable info(string username)
        {
            DataTable datos = new DataTable();

            con.Open();

            string llenar = "SELECT c.nro_cuenta, c.monto_cuenta, c.tipo_cuenta, c.tasainteres_cuenta, c.estado_cuenta, c.id_usuario " +
                            "FROM cuentas c INNER JOIN usuarios u ON u.id_usuario = c.id_usuario WHERE u.nombre_usuario = @username and c.estado_cuenta='DISPONIBLE';";

            MySqlCommand com = new MySqlCommand(llenar, con);
            com.Parameters.AddWithValue("@username", username);

            MySqlDataAdapter dat = new MySqlDataAdapter(com);
            dat.Fill(datos);

            con.Close();
            return datos;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            GridView1.DataSource = info(username);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            string nroCuenta = GridView1.Rows[index].Cells[0].Text;
            string monto = GridView1.Rows[index].Cells[1].Text;
            string tipo = GridView1.Rows[index].Cells[2].Text;
            string tasaInteres = GridView1.Rows[index].Cells[3].Text;
            string estado = GridView1.Rows[index].Cells[4].Text;
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //eliminar
            Button btn = (Button)sender;
            string numeroCuenta = btn.CommandArgument;
            MySqlCommand com = new MySqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText= "UPDATE cuentas SET estado_cuenta='CONGELADA' WHERE nro_cuenta=@numeroCuenta";
            com.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
            com.ExecuteNonQuery();
            con.Close();
            Button1_Click(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //EDITAR
            Button btn = (Button)sender;
            string username = TextBox1.Text;
            string numeroCuenta = btn.CommandArgument;
            Response.Redirect("WebForm2.aspx?user="+username+"&nroCu="+numeroCuenta+"&opcion=editar");
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //INSERTAR
            Button btn = (Button)sender;
            string username = TextBox1.Text;
            string numeroCuenta = btn.CommandArgument;
            Response.Redirect("WebForm2.aspx?user=" + username + "&nroCu=" + numeroCuenta + "&opcion=insertar");
        }


    }
}
