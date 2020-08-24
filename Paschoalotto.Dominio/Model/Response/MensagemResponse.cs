using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Model.Response
{
    public class MensagemResponse<T>
    {
        public bool ESucesso { get; set; }
        public T Dado { get; set; }
        public string Menssagem { get; set; }

        public static MensagemResponse<T> Criar(bool eSucesso,  T dado, string menssagem)
        {
            return new MensagemResponse<T>
            {
                ESucesso = eSucesso,
                Menssagem = menssagem,
                Dado = dado
            };
        }
    }
}
