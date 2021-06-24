using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySqlX.XDevAPI.Relational;
using System.Security.Cryptography;

namespace COMPLETE_FLAT_UI
{
    public partial class simulador : Form
    {
        int x_generadas;
        double x_atendidas;
        double promedio;
        public simulador()
        {
            InitializeComponent();
            button1.Enabled = false;
            btn_Ejecutar.Enabled = false;
            
        }

        //Método para generar un número random entre 2 números.  
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            dataGridView1.Rows.Clear();
            int personas_gen = RandomNumber(90, 150);
            txt_personas_generadas.Text = Convert.ToString(personas_gen);
            int tiempo_atencion;
            int contar;
            double suma=0;
            int horas_trabajo = Convert.ToInt32(combo_horas_trabajo.Text);
            int minutos_trabajo = horas_trabajo * 60;
            double total_personas_atendidas = 0;

            var seed = Environment.TickCount;
            var random = new Random(seed);


            for (contar=1; contar <= personas_gen&&suma<minutos_trabajo;contar++) {
                // txtResultados.Multiline = ("Persona " + contar + " tardo en ser atendida " + tiempo_atencion + "Minutos");
                dataGridView1.Rows.Add(contar, (tiempo_atencion= random.Next(3, 12))+ "Minutos");
                suma = suma + tiempo_atencion;
                total_personas_atendidas = total_personas_atendidas + 1;
            }
            promedio = (suma / total_personas_atendidas);
            promedio = Math.Round(promedio, 2);
        
            
            x_generadas = personas_gen;
            x_atendidas = contar-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void habilitarboton()
        {
            if (combo_horas_trabajo.Text != string.Empty)
            {
                
                btn_Ejecutar.Enabled = true;
            }
            else
            {
                
                btn_Ejecutar.Enabled = false;
            }
        }
        private void simulador_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("persona", "Persona");
            dataGridView1.Columns.Add("tardo", "Tardo en ser atendida");


        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      


        private void txt_personas_atendidas_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_dias_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarboton();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                     

            // Arreglos del Grafico
            string[] seriesArray = { "Personas que llegaron", "Personas que atendidas", "Promedio tiempo atención \n (Minutos)" };
            double[] pointsArray = { x_generadas, x_atendidas, promedio };

            // Se modifica la Paleta de Colores a utilizar por el control.
            // this.chart1.Palette = ChartColorPalette.SeaGreen;
            // Se agrega un titulo al Grafico.
         
            // Agregar las Series al Grafico.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Aqui se agregan las series o Categorias.
                //Series series = this.chart1.Series.Add(seriesArray[i]);
                // Aqui se agregan los Valores.
                chart1.Series[0].Points.DataBindXY(seriesArray, pointsArray);
                //series.Points.Add(pointsArray[i]);
            }
            
            button1.Enabled = false;
            
        }

    }
}
