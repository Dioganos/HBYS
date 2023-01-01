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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from poliklinik",con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaadı = textBox1.Text;
            string hastasoyadı = textBox2.Text;
            string poliklinikadı = textBox3.Text;
            string doktoradı = textBox4.Text;
            DateTime tarihi = monthCalendar1.SelectionStart.Date;
            TimeSpan saati = TimeSpan.Parse(textBox5.Text);
            DateTime tarihsaat = tarihi + saati;
            OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb"); bağlantı.Open();
            string randevuekle = "insert into poliklinik(hasta_adi,hasta_soyadi,poliklinik_adi,doktor_adi,tarih) values(@hastaadı,@hastasoyadı,@poliklinikadı,@doktoradı,@tarihi)";
            OleDbCommand ekle = new OleDbCommand(randevuekle, bağlantı);
            ekle.Parameters.Add("@hastaadı", OleDbType.Char, 50).Value = hastaadı;
            ekle.Parameters.Add("@hastasoyadı", OleDbType.Char, 50).Value = hastasoyadı;
            ekle.Parameters.Add("@poliklinikadı", OleDbType.Char, 50).Value = poliklinikadı;
            ekle.Parameters.Add("@doktoradı", OleDbType.Char, 50).Value = doktoradı;
            ekle.Parameters.Add("@tarihi", OleDbType.Date).Value = tarihsaat;
            ekle.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Randevu kaydedildi.");

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from poliklinik",bağlantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form1"].Show();
            this.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Show();
        }
    }
}
