using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace WCFCrumen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Icrumen_service" in both code and config file together.
    [ServiceContract]
    public interface Icrumen_service
    {
        //[OperationContract]
        //int DoWork(int num1, int num2);
        
        [OperationContract]
        int _IUD(string query);

        [OperationContract]
        DataTable Consulta(string query);

        [OperationContract] 
        string test();

        [OperationContract]
        int DoWork(int num1, int num2);
    }
}
