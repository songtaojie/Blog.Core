using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断该类型上是否有指定的属性
        /// </summary>
        /// <typeparam name="T">属性的类型</typeparam>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type)where T:Attribute
        {
            if (type == null) return false;
            T attribute =  type.GetCustomAttribute<T>();
            return attribute != null;
        }
    }
}
