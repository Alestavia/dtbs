using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (baglanti.State == ConnectionState.Open) 
                MessageBox.Show("baglanti var");
            else
                MessageBox.Show("baglanti yok");

            




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            dataSet1.Clear();
            Adaptor.SelectCommand = new OleDbCommand("select * from isimler", baglanti);
            Adaptor.Fill(dataSet1, "isimler");
            Gridisimler.DataSource = dataSet1.Tables["isimler"];
            Adaptor.Dispose();
            baglanti.Close();
            Gridisimler.Columns[0].Visible = false;
            Gridisimler.Columns[1].Visible = "iSİM";
            Gridisimler.Columns[2].Visible = "SOYİSİM";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gridisimler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Gridisimler_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Gridisimler.CurrentRow.Cells[1].Value.ToString;
             textBox2.Text=Gridisimler.CurrentRow.Cells[2].Value.ToString;
            textBox3.Text=Gridisimler.CurrentRow.Cells[3].Value.ToString;
             textBox4.Text=Gridisimler.CurrentRow.Cells[4].Value.ToString;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
             
    }
         
   }
            
