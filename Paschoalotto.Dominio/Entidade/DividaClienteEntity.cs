using Paschoalotto.Dominio.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Entidade
{
    public class DividaClienteEntity : Entity
    {
        public int ClienteID { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public PropostaEntity Proposta { get; set; }
    }
}
