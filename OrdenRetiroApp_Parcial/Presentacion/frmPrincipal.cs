using OrdenRetiroApp_Parcial.Presentacion;
using OrdenRetiroApp_Parcial.Servicios.Implementacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenRetiroApp_Parcial
{
    public partial class frmPrincipal : Form
    {
        FabricaServicio fabricaServicio = null;
        public frmPrincipal(FabricaServicio fabricaServicio)
        {
            InitializeComponent();
            this.fabricaServicio=fabricaServicio;
           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void ordenDeRetiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenRetiro ordenRetiro = new frmOrdenRetiro(fabricaServicio);
            ordenRetiro.Show();
        }
    }
}
