using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSServicos
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "Devolve o valor do tipo de exame feito")]
        public float GetExameValor(string tipo)
        {
            float res;
            switch (tipo)
            {
                case "RX":
                    res = 15F;
                    break;
                case "ECG":
                    res = 10F;
                    break;
                case "TAC":
                    res = 20F;
                    break;
                case "Hemograma":
                    res = 5F;
                    break;
                default:
                    res = 0;
                    break;
            }
            return res;
        }

    }
}
