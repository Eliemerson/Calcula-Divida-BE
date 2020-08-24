using Paschoalotto.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Model.Response
{
    public class PropostaModel
    {
        public DateTime DataVencimento { get; set; }
        public DateTime DataAtual { get; set; }
        public int QtdMaximaParcelas { get; set; }
        public double ValorOriginal { get; set; }
        public double ValorFinal { get; set; }
        public double ValorJuros { get; set; }
        public string ContatoColaborador { get; set; }
        public int DiasAtraso { get; set; }
    }
}