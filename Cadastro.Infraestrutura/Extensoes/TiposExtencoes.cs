using Newtonsoft.Json;

namespace Cadastro.Infraestrutura.Extensoes

{
    public static class TiposExtencoes
    {
        public static string ParaJson(this object clienteModelo) => JsonConvert.SerializeObject(clienteModelo);
    }
}