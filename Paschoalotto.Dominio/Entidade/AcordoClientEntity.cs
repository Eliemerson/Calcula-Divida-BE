using Paschoalotto.Dominio.Enum;
using Paschoalotto.Dominio.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Entidade
{
    public class AcordoClientEntity : Entity
    {
        public DateTime DataAcordo { get; set; }
        public PropostaEntity Proposta { get; set; }
        public int PropostaId { get; set; }
        public double Comissao { get; set; }
        public double Juros { get; set; }
        public double ValorFinal { get; set; }
        public double TaxaJuros { get; set; }
        public double ValorParcela { get; set; }
        public string VencimentoParcelas { get; set; }
        public TipoJurosEnum TipoJuros { get; set; }

        public  static AcordoClientEntity ValidarECriar(AcordoClientModel model, PropostaEntity propostaEntity) 
        {
            var valorJuros = propostaEntity.CalculaJuros();
            var valorFinal = valorJuros + propostaEntity.Divida.Valor;
            var somaParcelas = model.ValorParcela * model.ParcelaSelecionada;
            if (valorFinal != model.ValorFinal && somaParcelas != model.ValorFinal)
                return null;


            return new AcordoClientEntity()
            {
                DataAcordo = DateTime.Now,
                ValorFinal = model.ValorFinal,
                TipoJuros = propostaEntity.Juros.TipoJuros,
                ValorParcela = model.ValorParcela,
                PropostaId = model.PropostaId,
                VencimentoParcelas = model.VencimentoParcelas,
                TaxaJuros = propostaEntity.Juros.Valor,
                Comissao = (model.ValorFinal * propostaEntity.PorcentagemComissao) / 100,
                Juros = valorJuros,

            };
        }
    }
}
