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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isValidLogin = false;
        OleDbConnection conn;
        DataTable loginTable = new DataTable();
        DataRow loginData = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            dataGridView1.Visible = false;
            comboBox1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            chart1.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");

            OleDbDataAdapter adData = new OleDbDataAdapter("select * from Kullanıcı", conn);
            adData.Fill(loginTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usrName = textBox1.Text;
            string pwdName = textBox2.Text;
            foreach (DataRow row in loginTable.Rows)
            {
                if (row["Kullanıcı_Adı"].ToString() == usrName && row["Şifre"].ToString() == pwdName)
                {
                    isValidLogin = true;
                    loginData = row;
                    break;
                }
            }

            if (isValidLogin)
            {
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label3.Visible = false;

                if (loginData["Yetki"].ToString() == "Doktor")
                {
                    checkBox1.Visible = true;
                    dataGridView1.Visible = true;
                    comboBox1.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    chart1.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    DataTable hk = new DataTable();
                    OleDbDataAdapter hkData = new OleDbDataAdapter("select distinct servis_adı from hasta_detay", conn);
                    hkData.Fill(hk);
                    comboBox1.ValueMember = "hasta_no";
                    comboBox1.DisplayMember = "servis_adı";
                    comboBox1.DataSource = hk;
                }
                else if(loginData["Yetki"].ToString()== "Tekniker")
                {
                    checkBox1.Visible = true;
                    dataGridView1.Visible = true;
                    comboBox1.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    button2.Visible = true;
                    button2.Enabled = false;
                    button3.Visible = true;
                    button3.Enabled = false;
                    chart1.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button5.Enabled = false;
                    DataTable hk = new DataTable();
                    OleDbDataAdapter hkData = new OleDbDataAdapter("select distinct servis_adı from hasta_detay", conn);
                    hkData.Fill(hk);
                    comboBox1.ValueMember = "hasta_no";
                    comboBox1.DisplayMember = "servis_adı";
                    comboBox1.DataSource = hk;
                }
                else if (loginData["Yetki"].ToString() == "İzleyici")
                {
                    button4.Visible=true;
                    chart1.Visible=true;
                    button4.Location = new Point(295,221);
                    chart1.Location = new Point(587,12);
                    DataTable hk = new DataTable();
                    OleDbDataAdapter hkData = new OleDbDataAdapter("select distinct servis_adı from hasta_detay", conn);
                    hkData.Fill(hk);
                    comboBox1.ValueMember = "hasta_no";
                    comboBox1.DisplayMember = "servis_adı";
                    comboBox1.DataSource = hk;
                }
            }
            else
            {
                label3.Text = "giris basarisiz";
            }

        }


        

        private void button2_Click_1(object sender, EventArgs e)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(@"./deneme.pdf", FileMode.Create));

            if (document.IsOpen() == false)
            {
                document.Open();
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/logo.jpg");
                img.ScalePercent(24f);
                document.Add(img);
                document.Add(new Paragraph("Adı :" + textBox3.Text));
                document.Add(new Paragraph("Soyadı :" + textBox4.Text));
                document.Add(new Paragraph("Dogum tarihi :" + textBox5.Text));
                document.Add(new Paragraph("Telefon :" + textBox6.Text));
                document.Close();
            }

        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb"); conn.Open();
                DataTable dt = new DataTable();
                string komut = "select * from hasta_kayit_tablo where hasta_no =" + dataGridView1.SelectedRows[0].Cells[0].Value;
                OleDbCommand dc = new OleDbCommand(komut, conn);
                OleDbDataReader rdr = dc.ExecuteReader();
                while (rdr.Read())
                {
                    textBox3.Text = rdr["hasta_adı"].ToString();
                    textBox4.Text = rdr["hasta_soyadı"].ToString();
                    textBox5.Text = rdr["dogum_tarihi"].ToString();
                    textBox6.Text = rdr["tel"].ToString();
                }
            }
            catch { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 raporlama = new Form2();
            raporlama.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from hasta_detay", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                comboBox1.Enabled = false;
            }
            else
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter("select * from hasta_detay where servis_adı = '" + comboBox1.Text + "'", conn);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    comboBox1.Enabled = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from hasta_detay where servis_adı = '" + comboBox1.Text + "'", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series["servis"].Points.Clear();
            string[] servis = new string[20];
            int[] sayı = new int[20];
            servis[0] = "DAHİLİ YOĞUN BAKIM";
            servis[1] = "FİZİK TEDAVİ REHABİLİTASYON KLİNİĞİ";
            servis[2] = "GÖĞÜS HASTALIKLARI KLİNİĞİ";
            servis[3] = "KALP VE DAMAR CERRAHİ KLİNİĞİ";
            servis[4] = "NÖROLOJİ KLİNİĞİ";
            OleDbCommand sor = new OleDbCommand("select * from hasta_detay", conn);
            OleDbDataReader oku = sor.ExecuteReader();
            while (oku.Read())
            {
                for (int i = 0; i < 5; i++)
                {
                    if (servis[i] == oku[1].ToString()) { sayı[i]++;}
                }
            }
            for (int i = 0; i < 5; i++) chart1.Series["servis"].Points.AddXY(servis[i], sayı[i]);

            int sayaç = 0;
            do
            {
                comboBox1.SelectedIndex = sayaç;
                servis[sayaç] = comboBox1.Text;
                sayaç++;
            } while (sayaç < comboBox1.Items.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 randevu = new Form3();
            randevu.Show();
            this.Hide();
        }
    }
}
