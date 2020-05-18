namespace Cadastro.Dominio.Abstracoes
{
    public abstract class Modelo<T> where T : Entidade
    {
        public virtual void CopiarDaEntidade(T entidade)
        {
        }
    }
}