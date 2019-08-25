using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.Dependency
{
    /// <summary>
    /// 每个请求一个实例
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface|AttributeTargets.Class)]
    public class ScropedDependencyAttribute:Attribute
    {
    }
}
