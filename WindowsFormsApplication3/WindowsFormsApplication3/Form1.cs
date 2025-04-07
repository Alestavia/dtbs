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
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bağlantı_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (baglanti.State == ConnectionState.Open) 
            
                MessageBox.Show("Bağlantı var");
            
            else
            
                MessageBox.Show("bağlantı yok");

            baglanti.Close();
        }




        void listele()
        { 
        
         dataSet1.Clear();
            Atapter.SelectCommand = new OleDbCommand("select * from nick", baglanti);
            Atapter.Fill(dataSet1,"nick");
            Gridisimler.DataSource = dataSet1.Tables["nick"];
            Atapter.Dispose();
        
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            listele();
            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Atapter.InsertCommand = new OleDbCommand("insert into nick(isimler,soyad,ürün,fiyat) values (@isim,@soyisim,@urun,@fiyat)", baglanti);
            Atapter.InsertCommand.Parameters.AddWithValue("@isim", textBox1.Text);
            Atapter.InsertCommand.Parameters.AddWithValue("@soyisim", textBox2.Text);
            Atapter.InsertCommand.Parameters.AddWithValue("@urun", textBox3.Text);
            Atapter.InsertCommand.Parameters.AddWithValue("@fiyat", textBox4.Text);
            Atapter.InsertCommand.ExecuteNonQuery();
            listele();
            

            baglanti.Close();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        void temizle()
        { 
        textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gridisimler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Gridisimler_GridColorChanged(object sender, EventArgs e)
        {

        }

        private void Gridisimler_SelectionChanged(object sender, EventArgs e)
        {
            if (Gridisimler.CurrentRow!=null)
            {
                 textBox1.Text = Gridisimler.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Gridisimler.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = Gridisimler.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = Gridisimler.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                temizle();
            }
           
        }
    }
}
