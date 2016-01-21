using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WCFCrumen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "crumen_service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select crumen_service.svc or crumen_service.svc.cs at the Solution Explorer and start debugging.
    public class crumen_service : Icrumen_service
    {
        public string test()
        {
            return "hello";
        } 

        public int DoWork(int num1, int num2)
        {
            database data = new database();
            int Result = num1 + num2;
            int Res = Result + database.test();
            return Res;
        }

        public int _IUD(string query)
        {
            int datos = database.ExecuteNonQuery(query);
            return datos;
        }

        public DataTable Consulta(string query)
        {
            DataTable dt = database.Query(query);
            return dt;
        }

    }
}
