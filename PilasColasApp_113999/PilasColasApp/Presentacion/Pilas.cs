using PilasColasApp.Clases;
using PilasColasApp.Interfaces;
using System.Windows.Forms;

namespace PilasColasApp
{
    public partial class Pilas : Form
    {
        private IColeccion coleccion;
        public Pilas()
        {
            InitializeComponent();
            coleccion = new Pila(20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtElemento.Text))
            {
                object elemento = txtElemento.Text;
                if (coleccion.a�adir(elemento))
                {
                    lstElemento.Items.Add(elemento);
                    MessageBox.Show("Elemento A�adido", "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lista llena!", "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (!coleccion.estaVacia())
                MessageBox.Show("Primer elemento: " + coleccion.primero(), "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVacia_Click(object sender, EventArgs e)
        {
            string mensaje = coleccion.estaVacia() ? "Pila vac�a" : "Pila con elementos";
            MessageBox.Show(mensaje, "Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            object elemento = coleccion.extraer();
            lstElemento.Items.Remove(elemento);
        }

    }
}