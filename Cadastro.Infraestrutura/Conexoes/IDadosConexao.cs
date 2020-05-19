using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infraestrutura.Conexoes
{
    public interface IDadosConexao
    {
        static string ConexaoBancoSql { get; }
    }
}