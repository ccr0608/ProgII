using OrdenRetiroApp_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiroApp_Parcial.Servicios.Implementacion
{
    public class FabricaServicio : IFabricaServicio
    {
        public IServicio CrearServicio()
        {
            return new Servicio();  
        }
    }
}
