using OrdenRetiroApp_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiroApp_Parcial.Servicios.Interfaz
{
     public interface IServicio
    {
        List<Material> TraerMateriales();

        bool GrabarOrdenRetiro(OrdenRetiro oOrdenRetiro);

        bool ComprobarStock(int cantidad, Material material);

        int TraerNuevaOrdenRetiro();


    }
}
