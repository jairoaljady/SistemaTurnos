using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace COMPLETE_FLAT_UI
{
    public partial class FormListaClientes : Form
    {
        int poc;
        
        public FormListaClientes(string nombre)
        {
            InitializeComponent();
            label2.Text = nombre;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Cargar()
        {
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            bd.Open();

            try
            {
                MySqlCommand cmd = bd.CreateCommand();
                cmd.CommandText = "SELECT * FROM visitantes";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (bd.State == ConnectionState.Open)
                {
                    bd.Clone();
                }
            }


        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            Cargar();
         
        }

       
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
        
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            int telefono;
            string Nombre_label = textBox1.Text;
            string CURP_label = textBox2.Text;
            string AREA_label = comboBox1.Text;
            string TEL_label = textBox4.Text;
            int.TryParse(TEL_label, out telefono);
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            MySqlCommand cmd;
            MySqlCommand cmd2;
            bd.Open();

            try
            {
                cmd = bd.CreateCommand();
                cmd2 = bd.CreateCommand();

                if (comboBox1.Text == "TRÁMITES")
                {
                    cmd.CommandText = "INSERT INTO tramites(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                else if (comboBox1.Text == "CONSULTAS Y PAGOS")
                {
                    cmd.CommandText = "INSERT INTO pagos(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO documentacion(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                    cmd2.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                }
                //cmd.CommandText = "INSERT INTO visitantes(NOMBRE,CURP,AREA,TELEFONO)VALUES(@Nombre,@Curp,@Area,@Telefono)";
                cmd.Parameters.AddWithValue("@Nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@Curp", textBox2.Text);
                cmd.Parameters.AddWithValue("@Area", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.ExecuteNonQuery();
                cmd2.Parameters.AddWithValue("@Nombre", textBox1.Text);
                cmd2.Parameters.AddWithValue("@Curp", textBox2.Text);
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
                    Cargar();
                    bd.Close();
                }
            }
        }

        void limpiar()
        {
            btnNuevo.Enabled = false;
            BUTON_ELIMINAR.Enabled = false;
            BUTON_ACTUALIZAR.Enabled = false;
            TEXTBOX_ID.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
        }
       

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*FormMembresia frm = Owner as FormMembresia;
            //FormMembresia frm = new FormMembresia();

            frm.txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.Close();
            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        //ACTIVAR SI QUIERES QUE EN AUTOMATICO TE ACTUALICE LOS DATOS DE LA BD EN EL PANEL CADA 5 SEGUNDOS.
      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            Cargar();
        }*/

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int lx, ly;
        int sw, sh;

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnCerrar_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            BUTON_ELIMINAR.Enabled = false;
            int telefono;
            string Nombre_label = textBox1.Text;
            string CURP_label = textBox2.Text;
            string AREA_label = comboBox1.Text;
            string TEL_label = textBox4.Text;
            int.TryParse(TEL_label, out telefono);
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            MySqlCommand cmd;
            MySqlCommand cmd2;
            bd.Open();

            try
            {

                cmd2 = bd.CreateCommand();
               
                cmd2.CommandText = "UPDATE visitantes SET NOMBRE=@Nombre, CURP=@Curp, AREA=@Area, TELEFONO=@Telefono WHERE ID=@ID";   
                cmd2.Parameters.AddWithValue("@ID", TEXTBOX_ID.Text);
                cmd2.Parameters.AddWithValue("@Nombre", textBox1.Text);
                cmd2.Parameters.AddWithValue("@Curp", textBox2.Text);
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
                    MessageBox.Show("¡Registro actualizado!");
                    Cargar();
                    bd.Close();
                }
            }
        }

        private void label_NOMBRE_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevo.Enabled = false;
            button_LIMPIAR.Enabled = true;
            BUTON_ACTUALIZAR.Enabled = true;
            BUTON_ELIMINAR.Enabled = true;
            poc = dataGridView1.CurrentRow.Index;
            TEXTBOX_ID.Text = dataGridView1[0, poc].Value.ToString();
            textBox1.Text = dataGridView1[1, poc].Value.ToString();
            textBox2.Text = dataGridView1[2, poc].Value.ToString();
            comboBox1.Text = dataGridView1[3, poc].Value.ToString();
            textBox4.Text = dataGridView1[4, poc].Value.ToString();

            

        }
        public void habilitarboton()
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox1.Text != string.Empty && textBox4.Text != string.Empty)
            {
                btnNuevo.Enabled = true;
            }
            else
            {
                btnNuevo.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            habilitarboton();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            habilitarboton();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarboton();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            habilitarboton();
        }

        private void BUTON_ELIMINAR_Click(object sender, EventArgs e)
        {
                      
            int telefono;
            string Nombre_label = textBox1.Text;
            string CURP_label = textBox2.Text;
            string AREA_label = comboBox1.Text;
            string TEL_label = textBox4.Text;
            int.TryParse(TEL_label, out telefono);
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            MySqlCommand cmd;
            MySqlCommand cmd2;
            bd.Open();

            try
            {

                cmd2 = bd.CreateCommand();

                cmd2.CommandText = "DELETE FROM visitantes WHERE ID=@ID";
                cmd2.Parameters.AddWithValue("@ID", TEXTBOX_ID.Text);
                cmd2.Parameters.AddWithValue("@Nombre", textBox1.Text);
                cmd2.Parameters.AddWithValue("@Curp", textBox2.Text);
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
                    MessageBox.Show("¡Registro eliminado!");
                    Cargar();
                    bd.Close();
                }
            }

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
