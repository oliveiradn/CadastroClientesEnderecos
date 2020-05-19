using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastro.Dominio.Entidades.Clientes
{
    public class ClienteServico
    {
        public static IEnumerable<ClienteModelo> CriarListaClientesModelo(IEnumerable<Cliente> clientes)
        {
            var clientesModelo = new List<ClienteModelo>();

            if (clientes.Any())
                foreach (var cliente in clientes)
                {
                    var clienteModelo = new ClienteModelo();
                    clienteModelo.CopiarDaEntidade(cliente);
                    clientesModelo.Add(clienteModelo);
                }

            return clientesModelo;
        }
    }
}