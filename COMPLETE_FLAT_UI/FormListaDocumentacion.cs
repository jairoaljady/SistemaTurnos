using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace COMPLETE_FLAT_UI
{
    public partial class FormListaDocumentacion : Form
    {
        public FormListaDocumentacion(string nombre)
        {
            InitializeComponent();
            label1.Text = nombre;
        }

        public void Cargar()
        {
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            bd.Open();

            try
            {
                MySqlCommand cmd = bd.CreateCommand();
                cmd.CommandText = "SELECT * FROM documentacion";
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }
        int lx, ly;
        int sw, sh;

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormListaDocumentacion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        void limpiar()
        {
            TEXTBOX_ID.Text = "";
            txtNombre.Text = "";
            txtCURP.Text = "";
            Combo1.Text = "";
            txtTelefono.Text = "";
        }
        private void button_LIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int poc2 = dataGridView1.CurrentRow.Index;
            TEXTBOX_ID.Text = dataGridView1[0, poc2].Value.ToString();
            txtNombre.Text = dataGridView1[1, poc2].Value.ToString();
            txtCURP.Text = dataGridView1[2, poc2].Value.ToString();
            Combo1.Text = dataGridView1[3, poc2].Value.ToString();
            txtTelefono.Text = dataGridView1[4, poc2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int telefono;
            string Nombre_label = txtNombre.Text;
            string CURP_label = txtCURP.Text;
            string AREA_label = Combo1.Text;
            string TEL_label = txtTelefono.Text;
            int.TryParse(TEL_label, out telefono);
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            MySqlCommand cmd2;
            bd.Open();

            try
            {

                cmd2 = bd.CreateCommand();

                cmd2.CommandText = "DELETE FROM documentacion WHERE TURNO=@ID";
                cmd2.Parameters.AddWithValue("@ID", TEXTBOX_ID.Text);
                cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@Curp", txtCURP.Text);
                cmd2.Parameters.AddWithValue("@Area", Combo1.SelectedItem);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
