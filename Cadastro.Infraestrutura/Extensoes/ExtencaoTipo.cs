using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Cadastro.Infraestrutura.Extensoes

{
    public static class ExtencaoTipo
    {
        public static string ParaJson(this object clienteModelo) => JsonConvert.SerializeObject(clienteModelo);

        public static string RemoverCaracterEspecial(this string cpf) => cpf.Replace("-", "").Replace(".", "");

        public static string AdicionarCaracterEspecial(this string cpf) => new Regex(@"/ (\d{3})(\d{3})(\d{3})(\d{2})/g").Replace(@"/ (\d{3})(\d{3})(\d{3})(\d{2})/g", cpf);
    }
}