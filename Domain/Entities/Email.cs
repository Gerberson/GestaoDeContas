using System.Collections.Generic;

namespace Domain.Entities
{
    public class Email : EntityBase
    {
        public string De { get; private set; }
        public string Para { get; private set; }
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }
        public List<Anexo> Anexos { get; set; }

        public Email()
        {

        }

        public Email(string de, string para, string assunto, string mensagem)
        {
            De = de;
            Para = para;
            Assunto = assunto;
            Mensagem = mensagem;
        }
    }
}
