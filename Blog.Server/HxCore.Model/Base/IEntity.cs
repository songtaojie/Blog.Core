using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.Base
{
    public interface IEntity<T>
    {
         T Id { get; set; }
    }
}
