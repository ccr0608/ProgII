namespace CARRERASAPP.Presentacion
{
    partial class frmReporte
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSCarreras = new CARRERASAPP.Reportes.DSCarreras();
            this.dSCarrerasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCarreras1 = new CARRERASAPP.Reportes.DSCarreras();
            this.spconsultarcarrerasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_consultar_carrerasTableAdapter = new CARRERASAPP.Reportes.DSCarrerasTableAdapters.sp_consultar_carrerasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSCarreras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCarrerasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCarreras1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spconsultarcarrerasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spconsultarcarrerasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CARRERASAPP.Reportes.RptCarreras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(565, 358);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSCarreras
            // 
            this.dSCarreras.DataSetName = "DSCarreras";
            this.dSCarreras.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dSCarrerasBindingSource
            // 
            this.dSCarrerasBindingSource.DataSource = this.dSCarreras;
            this.dSCarrerasBindingSource.Position = 0;
            // 
            // dSCarreras1
            // 
            this.dSCarreras1.DataSetName = "DSCarreras";
            this.dSCarreras1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spconsultarcarrerasBindingSource
            // 
            this.spconsultarcarrerasBindingSource.DataMember = "sp_consultar_carreras";
            this.spconsultarcarrerasBindingSource.DataSource = this.dSCarreras1;
            // 
            // sp_consultar_carrerasTableAdapter
            // 
            this.sp_consultar_carrerasTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 358);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.frmReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSCarreras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCarrerasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCarreras1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spconsultarcarrerasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dSCarrerasBindingSource;
        private Reportes.DSCarreras dSCarreras;
        private Reportes.DSCarreras dSCarreras1;
        private System.Windows.Forms.BindingSource spconsultarcarrerasBindingSource;
        private Reportes.DSCarrerasTableAdapters.sp_consultar_carrerasTableAdapter sp_consultar_carrerasTableAdapter;
    }
}