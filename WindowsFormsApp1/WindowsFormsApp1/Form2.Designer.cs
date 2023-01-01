namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button2 = new System.Windows.Forms.Button();
            this.database6DataSet1 = new WindowsFormsApp1.Database6DataSet();
            this.yatanhastaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yatan_hastaTableAdapter1 = new WindowsFormsApp1.Database6DataSetTableAdapters.yatan_hastaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.database6DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yatanhastaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(749, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 92);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(412, 20);
            this.textBox1.TabIndex = 2;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.yatanhastaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 131);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1113, 517);
            this.reportViewer1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "geri dön";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // database6DataSet1
            // 
            this.database6DataSet1.DataSetName = "Database6DataSet";
            this.database6DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yatanhastaBindingSource
            // 
            this.yatanhastaBindingSource.DataMember = "yatan_hasta";
            this.yatanhastaBindingSource.DataSource = this.database6DataSet1;
            // 
            // yatan_hastaTableAdapter1
            // 
            this.yatan_hastaTableAdapter1.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 660);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(1153, 699);
            this.MinimumSize = new System.Drawing.Size(1153, 699);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database6DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yatanhastaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Database6DataSet database6DataSet;
        private Database6DataSetTableAdapters.yatan_hastaTableAdapter yatan_hastaTableAdapter;
        private System.Windows.Forms.Button button2;
        private Database6DataSet database6DataSet1;
        private System.Windows.Forms.BindingSource yatanhastaBindingSource;
        private Database6DataSetTableAdapters.yatan_hastaTableAdapter yatan_hastaTableAdapter1;
    }
}