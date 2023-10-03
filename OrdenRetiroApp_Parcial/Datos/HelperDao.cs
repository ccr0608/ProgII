using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace OrdenRetiroApp_Parcial.Datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conexion;


        private HelperDao() 
        {
            conexion= new SqlConnection(Properties.Resources.CadenaConexion1);
        }
         public static HelperDao ObtenerInstancia()
        { 
            if(instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia; 
        }

        public int ConsultarEscalar(string nombreSp, string paramSalida)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSp; 
            SqlParameter parametro= new SqlParameter();
            parametro.ParameterName = paramSalida;
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(parametro);  
            cmd.ExecuteNonQuery();

            conexion.Close();
            return (int)parametro.Value;
        }

        public DataTable Consultar(string nombreSp)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType= CommandType.StoredProcedure;   
            cmd.CommandText = nombreSp;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;
        }
    
        public DataTable Consultar(string nombreSp, List<Parametro>lstParametros)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType=CommandType.StoredProcedure;    
            cmd.CommandText = nombreSp;
            foreach (Parametro p in lstParametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);//esto viene del class parametro
            }
            DataTable tabla=new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;

        }
        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
    
}
