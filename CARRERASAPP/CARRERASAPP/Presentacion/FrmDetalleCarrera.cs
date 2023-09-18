using System;
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
    public partial class FrmDetalleCarrera : Form
    {
        private int id;

        public FrmDetalleCarrera(int id_carrera)
        {
            InitializeComponent();
            this.Text+=id_carrera.ToString();
        }

        public int Id_carrera { get; set; }



        private void FrmDetalleCarrera_Load(object sender, EventArgs e)
        {

        }
    }
}
