using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Dominio.Entidade
{
    public class Entity
    {
        public int Id { get; protected set; }
        protected Entity() => Guid = Guid.NewGuid();
        public Guid Guid { get; protected set; }
        public bool IsNew => Id == 0;
    }
}
