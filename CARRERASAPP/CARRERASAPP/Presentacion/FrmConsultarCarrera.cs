using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CARRERASAPP.Datos;
using CARRERASAPP.Entidades;

namespace CARRERASAPP.Presentacion
{
    public partial class FrmConsultarCarrera : Form
    {

        DBHelper gestor;
        Carrera nuevo;

        public FrmConsultarCarrera()
        {
            InitializeComponent();
            gestor = new DBHelper();
            nuevo = new Carrera();
        }

        private void FrmConsultarCarrera_Load(object sender, EventArgs e)
        {
            CargarCarrera();
        }

        private void CargarCarrera()
        {
            DataTable tabla=gestor.ConsultarSP("sp_consultar_carreras");
            cboCarrera.DataSource=tabla;
            cboCarrera.ValueMember = tabla.Columns[0].ColumnName;
            cboCarrera.DisplayMember=tabla.Columns[1].ColumnName;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cboCarrera.SelectedIndex !=-1)
            {
               DataTable tabla = gestor.ConsultarSP("sp_consultar_carreras");
                dgvCarrera.Rows.Clear();
                foreach (DataRow fila in tabla.Rows)
                {
                    dgvCarrera.Rows.Add(new object[] { fila["Id_Carrera"].ToString(),
                                                       fila["Nombre"].ToString()});

                }
            }

        }

        private void dgvCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarrera.CurrentCell.ColumnIndex == 2)//posicion de acciones visibles en la grilla
            {
                int id = Convert.ToInt32(dgvCarrera.CurrentRow.Cells["ColIdCarrera"].Value.ToString());
                FrmDetalleCarrera detalle = new FrmDetalleCarrera(id);
                detalle.Id_carrera = id;
                detalle.ShowDialog();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cboCarrera.SelectedIndex != -1)
            {
                int id = (int)cboCarrera.SelectedValue;
                if (gestor.EliminarAsignatura(id))
                {
                    MessageBox.Show("Se registró la baja de la carrera!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("NO Se registró la baja de la carrera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
