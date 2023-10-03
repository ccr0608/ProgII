using OrdenRetiroApp_Parcial.Datos.Interfaz;
using OrdenRetiroApp_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrdenRetiroApp_Parcial.Datos.Implementacion
{
    public class OrdenRetiroDao :IOrdenRetiroDao
    {
        public int ordenNro = 0;

public bool Crear(OrdenRetiro oOrdenRetiro)
        {
            bool resultado = true;
            
            SqlTransaction t = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_ORDEN";
                comando.Parameters.AddWithValue("@responsable", oOrdenRetiro.responsable);

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                ordenNro = (int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;

                foreach (DetalleOrden dp in oOrdenRetiro.detalleOrden)
                {
                    cmdDetalle = new SqlCommand("INSERTAR_DETALLES", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_orden", ordenNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@codigo", dp.material.codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }
            catch
            {
                if(t !=null)
                t.Rollback();
                resultado = false;

            }
            finally
            {
                if(conexion != null && conexion.State != ConnectionState.Closed)
                   conexion.Close();
            }
            return resultado;
        }

        public List<Material> ObtenerMateriales()
        {
            List<Material> lstMateriales= new List<Material>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            foreach (DataRow fila in tabla.Rows)
            {
                int codigo = Convert.ToInt32(fila["codigo"]);
                string nombre= fila["nombre"].ToString();
                int stock = Convert.ToInt32(fila["stock"]);
                Material m= new Material(codigo, nombre, stock);
                lstMateriales.Add(m);
            }
            return lstMateriales;
        }

        public int ObtenerNroNuevaOrdenRetiro()
        {
            return ordenNro;
        }

        public bool ComprobarStock(int cantidad, Material material)
        {
            if( cantidad <= material.stock)
            {
                return true;
            }
            else
                return false;
        }
    }
}
