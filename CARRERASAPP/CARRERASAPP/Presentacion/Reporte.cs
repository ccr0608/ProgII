﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARRERASAPP.Presentacion
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSCarreras1.sp_consultar_carreras' Puede moverla o quitarla según sea necesario.
            this.sp_consultar_carrerasTableAdapter.Fill(this.dSCarreras1.sp_consultar_carreras);

            this.reportViewer1.RefreshReport();
        }
    }
}
