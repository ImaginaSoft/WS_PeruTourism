using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WS_PeruTourism.Models.PeruTourism;
using WS_PeruTourism.Repository.PeruTourism;

namespace WS_PeruTourism.AppCode
{
    public class PeruTourism
    {
        readonly PedidoDataAccess objPedidoDA = new PedidoDataAccess();

        public PedidoRS InsertaPedidoCliente(PedidoRQ objFormPedido) {

            PedidoRS resultado = new PedidoRS();

            resultado = objPedidoDA.InsertarPedido(objFormPedido);

            return resultado;

        }

    }
}