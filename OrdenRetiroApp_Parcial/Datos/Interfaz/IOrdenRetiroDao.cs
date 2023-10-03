using OrdenRetiroApp_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiroApp_Parcial.Datos.Interfaz
{
    public interface IOrdenRetiroDao
    {
        List<Material> ObtenerMateriales();
        bool Crear(OrdenRetiro oOrdenRetiro);
        bool ComprobarStock(int cantidad, Material material);
        int ObtenerNroNuevaOrdenRetiro();

    }
}
