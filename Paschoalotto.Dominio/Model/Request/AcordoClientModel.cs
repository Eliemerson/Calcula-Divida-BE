using Paschoalotto.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Model.Request
{
    public class AcordoClientModel
    {
        public DateTime DataAcordo { get; set; }
        public int PropostaId { get; set; }
        public int ParcelaSelecionada { get; set; }
        public double Comissao { get; set; }
        public double Juros { get; set; }
        public double ValorFinal { get; set; }
        public double TaxaJuros { get; set; }
        public double ValorParcela { get; set; }
        public string VencimentoParcelas { get; set; }
        public TipoJurosEnum TipoJuros { get; set; }
    }
}
