using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CARRERASAPP.Entidades;
using System.Windows.Forms;


namespace CARRERASAPP.Datos
{
    internal class DBHelper
    {
        private SqlConnection conexion;
        //private SqlCommand comando=new SqlCommand();
        private SqlCommand comando;

        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-62T08J6\SQLEXPRESS;Initial Catalog=CarrerasBD_Claudia;Integrated Security=True");
            comando = new SqlCommand();
        }

        // Configurar Comando: asociarlo con un objeto conexión y asignarle propiedades Text y Type
        private void ConfigurarComando()
        {
            comando.Connection = conexion;
            comando.CommandType= CommandType.StoredProcedure;
        }

        public DataTable ConsultarSP(string SPNombre)
        {
            DataTable tabla=new DataTable();
            conexion.Open();
            ConfigurarComando();
            comando.CommandText = SPNombre;
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            return tabla;
        }

        public DataTable Consultar(string nombreSP, List<Parametros> lstParametros)
        {
            conexion.Open();
            ConfigurarComando();
            comando.CommandText = nombreSP;
            comando.Parameters.Clear();
            foreach (Parametros p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
         public int ProximoId()
        {
            conexion.Open();
            ConfigurarComando();
            comando.CommandText = "SP_PROXIMO_ID";
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@next";
            parametro.DbType = DbType.Int32;
            parametro.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();
            return Convert.ToInt32(parametro.Value);

        }

        internal bool EliminarAsignatura(int id)
        {
            bool respuesta = true;
            SqlTransaction t = null;

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_DETALLEASIGNATURA", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_carrera", id);
                respuesta = cmd.ExecuteNonQuery() == 1;





                SqlCommand comando = new SqlCommand("SP_ELIMINAR_CARRERA", conexion, t);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_carrera", id);
                respuesta = comando.ExecuteNonQuery() == 1;

                t.Commit();
            }
            catch 
            {
                t.Rollback();
                respuesta = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return respuesta;
        }

        // Método Booleano que inserta tanto Maestro como Detalle utilizando una transacción

        public bool ConfirmarCarrera(Carrera oCarrera)
        {
            bool resultado = true;

            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();//se abre coneccion bajo transaccion
                SqlCommand comando=new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;//comienza una ejecucion bajo transaccion
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_insertar_carrera";
                comando.Parameters.AddWithValue("@nombre", oCarrera.NombreTitulo);

                //creo un parametro para recibir lo q manda el sp, es un parametro de salida
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@new_id_carrera";
                parametro.SqlDbType = SqlDbType.Int;//defino el tipo de parametro que es sql
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);//vinculo el parametro con el comando

                comando.ExecuteNonQuery();

                int id_Carrera = (int)parametro.Value;
                

                SqlCommand cmdDetalle;
                cmdDetalle = new SqlCommand("sp_insertar_detalleCarreras", conexion, t);
                cmdDetalle.CommandType = CommandType.StoredProcedure;
                //int detalleNro = 0;

                //foreach (DetalleCarreras dc in oCarrera.DetallesCarrera)
                //{

                //    cmdDetalle.Parameters.AddWithValue("@anioCursado", dc.AnioCursado);
                //    cmdDetalle.Parameters.AddWithValue("@cuatrimestre", dc.Cuatrimestre);
                //    cmdDetalle.Parameters.AddWithValue("@id_carrera", id_Carrera);
                //    cmdDetalle.Parameters.AddWithValue("@id_asignatura", dc.Asignatura.Id_asignatura);
                //    cmdDetalle.ExecuteNonQuery();
                //    detalleNro++;
                //}

                for (int i = 0; i < oCarrera.DetallesCarrera.Count; i++)
                {
                    cmdDetalle.Parameters.Clear();

                    cmdDetalle.Parameters.AddWithValue("@anioCursado", oCarrera.DetallesCarrera[i].AnioCursado);
                    cmdDetalle.Parameters.AddWithValue("@cuatrimestre", oCarrera.DetallesCarrera[i].Cuatrimestre);
                    cmdDetalle.Parameters.AddWithValue("@id_carrera", id_Carrera);
                    cmdDetalle.Parameters.AddWithValue("@id_asignatura", oCarrera.DetallesCarrera[i].Asignatura.Id_asignatura);

                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();

            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                    
            }

            return resultado;
        }

       
    

    }
}
