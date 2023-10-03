using OrdenRetiroApp_Parcial.Datos.Implementacion;
using OrdenRetiroApp_Parcial.Datos.Interfaz;
using OrdenRetiroApp_Parcial.Entidades;
using OrdenRetiroApp_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiroApp_Parcial.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IOrdenRetiroDao dao;

        public Servicio()
        {
            dao = new OrdenRetiroDao();
        }

        public bool ComprobarStock(int cantidad, Material material)
        {
            return dao.ComprobarStock(cantidad, material);
        }

        public bool GrabarOrdenRetiro(OrdenRetiro oOrdenRetiro)
        {
            return dao.Crear(oOrdenRetiro);
        }

        public List<Material> TraerMateriales()
        {
            return dao.ObtenerMateriales(); 
        }

        public int TraerNuevaOrdenRetiro()
        {
            return dao.ObtenerNroNuevaOrdenRetiro();    
        }
    }
}
