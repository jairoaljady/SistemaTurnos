using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace COMPLETE_FLAT_UI
{
    public partial class FormMantCliente : Form
    {
       
        public FormMantCliente()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
       
        public void habilitarboton()
        {
            if (txtnombre.Text!=string.Empty&& txtapellido.Text!=string.Empty&&comboBox1.Text!=string.Empty&& txttelefono.Text!=string.Empty)
                {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

    

        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            int telefono;
            string Nombre_label = txtnombre.Text;
            string CURP_label = txtapellido.Text;
            string AREA_label = comboBox1.Text;
            string TEL_label = txttelefono.Text;
            int.TryParse(TEL_label, out telefono);
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            MySqlCommand cmd;
            MySqlCommand cmd2;
            bd.Open();

            try
            {
                cmd = bd.CreateCommand();
                cmd2 = bd.CreateCommand();

                if(comboBox1.Text=="TRÁMITES")
                {
                    cmd.CommandText = "INSERT INTO tramites(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                else if(comboBox1.Text=="CONSULTAS Y PAGOS"){
                    cmd.CommandText = "INSERT INTO pagos(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                else 
                {
                    cmd.CommandText = "INSERT INTO documentacion(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                //cmd.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                cmd.Parameters.AddWithValue("@Curp", txtapellido.Text);
                cmd.Parameters.AddWithValue("@Area", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.ExecuteNonQuery();
                cmd2.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                cmd2.Parameters.AddWithValue("@Curp", txtapellido.Text);
                cmd2.Parameters.AddWithValue("@Area", comboBox1.SelectedItem);
                cmd2.Parameters.AddWithValue("@Telefono", telefono);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (bd.State == ConnectionState.Open)
                {   
                    MessageBox.Show("¡Registro guardado!");

                    bd.Close();
                    this.Close();
                }
            }

           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_KeyUp(object sender, KeyEventArgs e)
        {
            habilitarboton();
        }

        private void txtapellido_KeyUp(object sender, KeyEventArgs e)
        {
            habilitarboton();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            habilitarboton();
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            habilitarboton();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
