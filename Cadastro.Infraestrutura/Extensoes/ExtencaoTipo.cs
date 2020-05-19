using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Cadastro.Infraestrutura.Extensoes

{
    public static class ExtencaoTipo
    {
        public static string ParaJson(this object clienteModelo) => JsonConvert.SerializeObject(clienteModelo);

        public static string RemoverCaracterEspecial(this string cpf) => cpf.Replace("-", "").Replace(".", "");
    }
}