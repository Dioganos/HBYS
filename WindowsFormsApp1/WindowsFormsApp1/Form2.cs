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
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'database6DataSet1.yatan_hasta' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.yatan_hastaTableAdapter1.Fill(this.database6DataSet1.yatan_hasta);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb"); con.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from yatan_hasta where servis_adi = '" + textBox1.Text + "'", con);
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.Refresh();
            reportViewer1.RefreshReport();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form1"].Show();
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Show();
        }
    }
}
