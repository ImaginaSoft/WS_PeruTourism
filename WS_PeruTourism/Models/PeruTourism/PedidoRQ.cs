using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_PeruTourism.Models.PeruTourism
{
    [Serializable]
    public class PedidoRQ
    {
        public int NroPedido { get; set; }
        public string DesPedido { get; set; }

        public DateTime FchPedido { get; set; }

        public char CodVendedor { get; set; }


    }
}