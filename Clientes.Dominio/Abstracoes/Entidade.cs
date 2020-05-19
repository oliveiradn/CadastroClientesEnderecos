using DocumentosBrasileiros;
using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Cadastro.Dominio.Abstracoes
{
    public abstract class Entidade : Notifiable
    {
        [Key]
        public long Id { get; private set; }

        public void SetarId(long id) => Id = id;

        protected void Validar()
        {
            var contrato = ContratoBase(this);

            if (contrato.Valid)
                contrato = ConfigurarContrato(contrato);

            AddNotifications(contrato);
        }

        protected virtual bool ValidarCPF(string documento)
        {
            var numeros = new Regex("^[0-9]+$");
            var cpf = new Cpf();

            cpf.Numero = documento;

            if (numeros.IsMatch(cpf.Numero))
                return cpf.DocumentoValido();

            return false;
        }

        protected Contract ContratoBase(object entidade)
        {
            var contrato = new Contract();

            foreach (var property in entidade.GetType().GetProperties())
            {
                if (property.CustomAttributes.Any())
                {
                    if (property.GetValue(entidade) == null)
                        contrato.AddNotification(property.Name, $"{property.Name} de {entidade.GetType().Name} não pode ser nulo");
                    else if (string.IsNullOrEmpty(property.GetValue(entidade).ToString()))
                        contrato.AddNotification(property.Name, $"{property.Name} de {entidade.GetType().Name} não pode ser vazio");
                    else
                    {
                        var valor = property.GetValue(entidade).ToString();

                        if (SearchDatanotation(property, "RequiredAttribute") != null)
                            contrato.IsNotNullOrEmpty(valor, property.Name, $"{property.Name} de {entidade.GetType().Name} '{valor}' é obrigatório");

                        if (SearchDatanotation(property, "MaxLengthAttribute") != null)
                        {
                            var maxLength = (int)SearchDatanotation(property, "MaxLengthAttribute").ConstructorArguments[0].Value;
                            contrato.HasMaxLen(valor, maxLength, property.Name, $"{property.Name} de {entidade.GetType().Name} '{valor}' deve ter no máximo {maxLength} caracteres.");
                        }
                    }
                }
            }

            return contrato;
        }

        protected abstract Contract ConfigurarContrato(Contract contract);

        private static CustomAttributeData SearchDatanotation(PropertyInfo property, string dataAnotation) => property.CustomAttributes.Where(x => x.AttributeType.Name == dataAnotation).FirstOrDefault();
    }
}