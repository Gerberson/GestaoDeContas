using Domain.Enums;

namespace Domain.Entities
{
    public class Anexo : EntityBase
    {
        public int IdEmail { get; private set; }
        public string CnpjFornecedor { get; private set; }
        public TipoDeFatura TipoDeFatura { get; private set; }
        public Formato Formato { get; private set; }
        public Email Email { get; set; }

        public Anexo()
        {

        }

        public Anexo(string cnpjFornecedor, TipoDeFatura tipoDeFatura, Formato formato, Email email)
        {
            CnpjFornecedor = cnpjFornecedor;
            TipoDeFatura = tipoDeFatura;
            Formato = formato;
            Email = email;
        }
    }
}
