using System.Collections.Generic;

namespace Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public List<Layout> Layouts { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(string cnpj, string razaoSocial, string endereco, string numero, string cidade, string estado)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            Endereco = endereco;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
