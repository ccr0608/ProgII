using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CARRERASAPP.Presentacion;

namespace CARRERASAPP
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevaCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaCarrera nueva=new FrmNuevaCarrera();
            nueva.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarCarrera consultar=new FrmConsultarCarrera();
            consultar.ShowDialog(); 
        }

        private void deCarrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReporte().ShowDialog();
        }
    }
}
