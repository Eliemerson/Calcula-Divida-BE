using Paschoalotto.Dominio.Enum;
using Paschoalotto.Dominio.Model.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Entidade
{
    public class PropostaEntity : Entity
    {
        public int JurosId { get; set; }
        public int DividaId { get; set; }
        public DateTime DataProposta { get; set; }
        public int QtdMaximaParcelas { get; set; }
        public string ContatoColaborador { get; set; }
        public DividaClienteEntity Divida { get; set; }
        public TipoJurosEntity Juros { get; set; }
        public AcordoClientEntity Acordo { get; set; }
        public double PorcentagemComissao { get; set; }
        public StatusEnumProposta Status { get; set; }
        public double CalculaJuros()
        {
            return (Divida.Valor * (Juros.Valor * CalculaDias())) / 100;
        }
        public int CalculaDias() {
            return (DateTime.Now - Divida.DataVencimento).Days;
        }

        public static PropostaModel CriarComModel(PropostaEntity propostaEntity)
        {
            double juros = propostaEntity.CalculaJuros();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            return new PropostaModel
            {
                DataVencimento = propostaEntity.Divida.DataVencimento,
                QtdMaximaParcelas = propostaEntity.QtdMaximaParcelas,
                ValorOriginal = propostaEntity.Divida.Valor,
                ContatoColaborador = propostaEntity.ContatoColaborador,
                DiasAtraso = propostaEntity.CalculaDias(),
                ValorFinal = juros + propostaEntity.Divida.Valor,
                ValorJuros = juros,
                DataAtual = DateTime.Now
            };
        }

    }
}
