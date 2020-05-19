using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Dominio.Entidades.Enderecos
{
    public class EnderecoServico
    {
        public static IEnumerable<EnderecoModelo> CriarListaEnderecosModelo(IEnumerable<Endereco> Enderecos)
        {
            var enderecosModelo = new List<EnderecoModelo>();

            if (Enderecos.Any())
                foreach (var Endereco in Enderecos)
                {
                    var enderecoModelo = new EnderecoModelo();
                    enderecoModelo.CopiarDaEntidade(Endereco);
                    enderecosModelo.Add(enderecoModelo);
                }

            return enderecosModelo;
        }
    }
}