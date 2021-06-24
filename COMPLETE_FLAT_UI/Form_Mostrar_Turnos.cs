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
    public partial class Form_Mostrar_Turnos : Form
    {
        
        public Form_Mostrar_Turnos()
        {
            InitializeComponent();
            consulta_tramites();
            consulta_documentacion();
            consulta_pagos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void consulta_tramites()
        {
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            bd.Open();

            try
            {
                MySqlCommand cmd = bd.CreateCommand();
                MySqlCommand cmd2 = bd.CreateCommand();
                cmd.CommandText = "SELECT MIN(TURNO) FROM tramites";
               
               
                int maxId = Convert.ToInt32(cmd.ExecuteScalar());
                

                lbl_id_tramites.Text = maxId.ToString();
                cmd2.Parameters.AddWithValue("@TURNO", lbl_id_tramites.Text);
                cmd2.CommandText = "SELECT MIN(NOMBRE) FROM tramites WHERE TURNO=@TURNO";
                String maxIdNombre = cmd2.ExecuteScalar().ToString();
                lbl_nom_tramites.Text = maxIdNombre.ToString();

            }
            catch (Exception)
            {
                lbl_id_tramites.Text = "N/A";
                lbl_nom_tramites.Text = "N/A";
            }
            finally
            {
                if (bd.State == ConnectionState.Open)
                {
                    bd.Clone();
                }
            }
        }

        void consulta_documentacion()
        {
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            bd.Open();
            
            try
            {
                MySqlCommand cmd = bd.CreateCommand();
                MySqlCommand cmd2 = bd.CreateCommand();
                cmd.CommandText = "SELECT MIN(TURNO) FROM documentacion";

                int maxId = Convert.ToInt32(cmd.ExecuteScalar());
                

                lbl_id_doc.Text = maxId.ToString();
                cmd2.Parameters.AddWithValue("@TURNO", lbl_id_doc.Text);
                cmd2.CommandText = "SELECT MIN(NOMBRE) FROM documentacion WHERE TURNO=@TURNO";
                String maxIdNombre = cmd2.ExecuteScalar().ToString();
                lbl_nombre_doc.Text = maxIdNombre.ToString();
            }
            catch (Exception)
            {
                lbl_id_doc.Text = "N/A";
                lbl_nombre_doc.Text = "N/A";
            }
            finally
            {
                if (bd.State == ConnectionState.Open)
                {
                    bd.Clone();
                }
            }
        }
        void consulta_pagos()
        {
            MySqlConnection bd = new MySqlConnection("SERVER=localhost; DATABASE=bd_turnos; UID=root; PASSWORD=; PORT=3306");
            bd.Open();

            try
            {
                MySqlCommand cmd = bd.CreateCommand();
                MySqlCommand cmd2 = bd.CreateCommand();
                cmd.CommandText = "SELECT MIN(TURNO) FROM pagos";
              
                int maxId = Convert.ToInt32(cmd.ExecuteScalar());
                
                lbl_id_pagos.Text = maxId.ToString();
                cmd2.Parameters.AddWithValue("@TURNO", lbl_id_pagos.Text);
                cmd2.CommandText = "SELECT MIN(NOMBRE) FROM pagos WHERE TURNO=@TURNO";
                String maxIdNombre = cmd2.ExecuteScalar().ToString();
                lbl_nombre_pagos.Text = maxIdNombre.ToString();
            }
            catch (Exception)
            {
                lbl_id_pagos.Text = "N/A";
                lbl_nombre_pagos.Text = "N/A";
            }
            finally
            {
                if (bd.State == ConnectionState.Open)
                {
                    bd.Clone();
                }
            }
        }

        private void lbl_id_tramites_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
