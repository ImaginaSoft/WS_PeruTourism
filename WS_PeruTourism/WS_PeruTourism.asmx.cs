using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json;

using WS_PeruTourism.AppCode;
using WS_PeruTourism.Models.PeruTourism;

namespace WS_PeruTourism
{
    /// <summary>
    /// Summary description for WS_PeruTourism
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_PeruTourism : System.Web.Services.WebService
    {

        readonly PeruTourism _objPeruTourism = new PeruTourism();

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string InsertaPedidoClienteJson(PedidoRQ datos)
        //{

        //    PedidoRS Response = _objPeruTourism.gg(datos);

        //    var json = JsonConvert.SerializeObject(Response);

        //    return json;
        //}

        [WebMethod]
        public PedidoRS PedidoCliente( PedidoRQ objFormPedido)
        {

            PedidoRS Response = _objPeruTourism.InsertaPedidoCliente(objFormPedido);

            return Response;

        }



    }
}
