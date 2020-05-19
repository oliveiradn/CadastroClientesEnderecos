namespace Cadastro.Infraestrutura.Conexoes.Ambiente
{
    public abstract class DadosConexaoTeste : IDadosConexao
    {
        public static string ConexaoBancoSql => @"Server=QSBR-NB5\SQLEXPRESS;Database=TesteApi;Trusted_Connection=True;";
    }
}