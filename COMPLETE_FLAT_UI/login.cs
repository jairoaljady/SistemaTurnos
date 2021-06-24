using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace COMPLETE_FLAT_UI
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
           
            
        }
        MySqlConnection bd2 = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
        MySqlCommand cmd2;
        public void loguear(string usuario, string contrasena)
        {
            try
            {
                bd2.Open();
                cmd2 = bd2.CreateCommand();
                cmd2.CommandText = "SELECT Nombre, Tipo_usuario FROM usuarios WHERE Usuario=@usuario AND Password=@pass";
                cmd2.Parameters.AddWithValue("usuario", usuario);
                cmd2.Parameters.AddWithValue("pass", contrasena);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admingral")
                    {
                        new FormListaClientes(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "AdminTramites")
                    {
                        new FormListaTramites(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "AdminPagos")
                    {
                        new FormListaConsult_Pagos(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "AdminDocumentacion")
                    {
                        new FormListaDocumentacion(dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");

                }
                
                cmd2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                bd2.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loguear(this.textBox1.Text, this.textBox2.Text);
        }
    }
}
