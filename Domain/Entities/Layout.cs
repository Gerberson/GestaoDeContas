using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Layout : EntityBase
    {
        public int IdFornecedor { get; private set; }
        public string Descricao { get; private set; }
        public TipoDeFatura TipoDeFatura { get; private set; }
        public Formato Formato { get; private set; }
        public Fornecedor Fornecedor { get; set; }
        public List<Campo> Campos { get; set; }

        public Layout()
        {

        }

        public Layout(string descricao, TipoDeFatura tipoDeFatura, Formato formato, Fornecedor fornecedor)
        {
            Descricao = descricao;
            TipoDeFatura = tipoDeFatura;
            Formato = formato;
            Fornecedor = fornecedor;
        }
    }
}
