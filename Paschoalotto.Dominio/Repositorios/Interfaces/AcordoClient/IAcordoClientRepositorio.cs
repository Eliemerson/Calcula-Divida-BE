using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Repositorios.Interfaces.AcordoClient
{
    public interface IAcordoClientRepositorio
    {
        AcordoClientEntity Salvar(AcordoClientEntity model);

    }
}
