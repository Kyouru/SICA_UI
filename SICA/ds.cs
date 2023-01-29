using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICA
{
    internal class ds
    {

        private static string strConnectionDesa = "Data source=DESARROLLO_NEW;User Id=SISGODBA;Password=SISGODBA;";
        private static string strConnectionQA = "Data source=DESARROLLO_QA;User Id=SISGODBA;Password=SISGODBA;";
        private static string strConnectionProd = "Data source=BDPACIFICO;User Id=SISGODBA;Password=SISGODBA;";

        public static string getString(string ambiente)
        {
            string strconn = "";
            switch (ambiente)
            {
                case "QA":
                    strconn = strConnectionQA.Replace("DESARROLLO_QA", QA);
                    break;
                case "DESA":
                    strconn = strConnectionDesa.Replace("DESARROLLO_NEW", DESA);
                    break;
                case "PROD":
                    strconn = strConnectionProd.Replace("BDPACIFICO", PROD);
                    break;
                default:
                    strconn = strConnectionDesa.Replace("DESARROLLO_NEW", DESA);
                    break;
            }
            return strconn;
        }


        private static string DESA = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.1.1.50)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=desa)))";
        private static string QA = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.1.1.50)(PORT=1521)))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=qa)))";
        private static string PROD = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.9.190)(PORT=1521)))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=BDCOOPAC)))";

    }
}
