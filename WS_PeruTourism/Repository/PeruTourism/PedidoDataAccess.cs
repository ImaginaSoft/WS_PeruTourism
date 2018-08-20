using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WS_PeruTourism.Models.PeruTourism;

namespace WS_PeruTourism.Repository.PeruTourism
{
    public class PedidoDataAccess
    {

        public IEnumerable<PedidoRQ> ObtenerListadoPedido()
        {

            var lstPedido = new List<PedidoRQ>();

            using (SqlConnection objConnection = new SqlConnection(Data.Data.StrCnx_WebsSql))
            {

                using (SqlCommand objCommand = new SqlCommand())
                {

                    objCommand.CommandText = "SELECT * FROM CPEDIDO WHERE CodVendedor='MAYRA' AND FchPedido > = '2018-06-15';";
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Connection = objConnection;
                    objConnection.Open();

                    using (var reader = objCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            var pedido = new PedidoRQ
                            {
                                NroPedido = int.Parse(GetValue(reader, "NroPedido")),
                                DesPedido = GetValue(reader, "DesPedido"),
                                FchPedido = DateTime.Parse(GetValue(reader, "FchPedido"))
                            };
                            //pedido.CodVendedor = Convert.ToChar(GetValue(reader, "CodVendedor"));

                            lstPedido.Add(pedido);

                        }

                    }

                }

                return lstPedido;

            }

        }

        private string GetValue(IDataReader registo,
                           string columna)
        {
            var lvalue = registo[columna];

            return (((lvalue is DBNull) || (lvalue == null)) ? null : registo[columna].ToString());
        }


        public PedidoRS InsertarPedido(PedidoRQ objPedidoRQ)
        {

            PedidoRS resultado = new PedidoRS();

            try
            {
                using (SqlConnection objConnection = new SqlConnection(Data.Data.StrCnx_WebsSql))
                {

                    using (SqlCommand objCommand = new SqlCommand())
                    {

                        objCommand.CommandText = "";
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Connection = objConnection;

                        objCommand.Parameters.AddWithValue("@gg", objPedidoRQ.NroPedido);

                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();

                        //using (var reader = objCommand.ExecuteReader())
                        //{

                        //    while (reader.Read())
                        //    {

                        //        var pedido = new PedidoRQ
                        //        {
                        //            NroPedido = int.Parse(GetValue(reader, "NroPedido")),
                        //            DesPedido = GetValue(reader, "DesPedido"),
                        //            FchPedido = DateTime.Parse(GetValue(reader, "FchPedido"))
                        //        };
                        //        //pedido.CodVendedor = Convert.ToChar(GetValue(reader, "CodVendedor"));

                        //        lstPedido.Add(pedido);

                        //    }

                        //}

                    }

                    //return lstPedido;

                }

            }
            catch(Exception e)
            {

                resultado.MessageException = e.ToString();

            }

            return resultado;



        }



    }
}