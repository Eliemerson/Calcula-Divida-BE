using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Repositorios.Interfaces.AcordoClient;
using Paschoalotto.Repositorio.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Repositorio.Database.Repositorios
{
    public class AcordoClientRepositorio: RepositorioBase<AcordoClientEntity>,  IAcordoClientRepositorio
    {
        public AcordoClientRepositorio(PaschoalottoContext context) : base(context) { }


    }
}
