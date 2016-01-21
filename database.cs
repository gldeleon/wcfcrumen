using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WCFCrumen
{
    public class database
    {
        public static int test()
        {
            return 1;
        }

        private static SqlConnection cn;     //Cadena de conexion 

        /// <summary>
        /// Metodo para ejecutar una consulta o mandar a llamr un SP
        /// </summary>
        /// <param name="ProcdureOrQuery">Nombre del SP o consulta a ejecutar</param>
        /// <returns>Retorna un DataSet</returns>
        public static DataSet StoredProcedureOrQueryDs(String ProcdureOrQuery)
        {
            DataSet ds = new DataSet();
            string connstring = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand(ProcdureOrQuery, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns>Regresa total de filas afectadas</returns>
        public static int ExecuteNonQuery(String Query)
        {
            int RowsAfected = 0;
            try
            {
                using (cn = new SqlConnection())
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.CommandTimeout = 0;
                    RowsAfected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { throw new Exception(e.Number + e.Message); }
            return RowsAfected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Regresa DataTable con los datos del query SELECT</returns>
        public static DataTable Query(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (cn = new SqlConnection())
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception) { throw; }
            return dt;
        }
    }
}