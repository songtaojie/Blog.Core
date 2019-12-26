using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Entity.Base
{
    public interface IEntity<T>
    {
         T Id { get; set; }
    }
}
