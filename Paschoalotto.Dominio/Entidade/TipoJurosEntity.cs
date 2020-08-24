using Paschoalotto.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Entidade
{
    public class TipoJurosEntity : Entity
    {
        public TipoJurosEnum TipoJuros { get; set; }
        public double Valor { get; set; }
        public PropostaEntity Proposta { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Alteracao { get; set; }
    }
}
