using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Common.Extensions
{
    public static class IEnumerableExtensions
    {
		/// <summary>
		/// 排序冰粉也
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		public static PageModel<T> ToOrderAndPageList<T>(this IQueryable<T> source, BasePageParam param)
		{
			if (!string.IsNullOrWhiteSpace(param.SortKey))
			{
				source = source.ApplyOrder(param.SortKey, param.SortType);
			}
			return source.ToPageList(param);
		}

		/// <summary>
		/// 排序冰粉也
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		public async static Task<PageModel<T>> ToOrderAndPageListAsync<T>(this IQueryable<T> source, BasePageParam param)
		{
			if (!string.IsNullOrWhiteSpace(param.SortKey))
			{
				source = source.ApplyOrder(param.SortKey, param.SortType);
			}
			return await source.ToPageListAsync(param);
		}

		/// <summary>
		/// 排序
		/// </summary>
		/// <typeparam name="T">源数据</typeparam>
		/// <param name="source"></param>
		/// <param name="fieldName">排序的字段名称</param>
		/// <param name="sortType">排序的类型</param>
		/// <returns></returns>
		public static IQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string fieldName, SortTypeEnum sortType)
		{
			// 升序 or 降序
			string methodName = sortType == SortTypeEnum.DESC ? "OrderByDescending" : "OrderBy";
			// 属性
			var orderField = string.Empty;
			Type type = typeof(T);
			var properties = type.GetProperties();
			Type[] types = new Type[2];  //  参数：对象类型，属性类型
			types[0] = typeof(T);
			var isMatch = false;
			foreach (var p in properties)
			{
				isMatch = string.Equals(fieldName, p.Name, StringComparison.OrdinalIgnoreCase);
				if (isMatch)
				{
					orderField = p.Name;
					types[1] = p.PropertyType;
					break;
				}
			}
			ErrorHelper.ThrowIfFalse(isMatch, string.Format("This field {0} does not exist", fieldName));
			ParameterExpression param = Expression.Parameter(type, orderField);
			Expression orderFieldExp = Expression.Property(param, orderField);
			Expression expr = Expression.Call(typeof(Queryable), methodName, types,
				  source.Expression, Expression.Lambda(orderFieldExp, param));
			return source.Provider.CreateQuery<T>(expr);
		}


		/// <summary>
		/// 分页查询
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="param">分页的参数</param>
		/// <returns></returns>
		public static PageModel<T> ToPageList<T>(this IQueryable<T> source, BasePageParam param)
		{
			ErrorHelper.ThrowIfNull(param, "param is null");
			return source.ToPageList(param.PageIndex, param.PageSize);
		}

		/// <summary>
		/// 异步分页查询
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="pagemodel"></param>
		/// <returns></returns>
		public static async Task<PageModel<T>> ToPageListAsync<T>(this IQueryable<T> source, BasePageParam param)
		{
			ErrorHelper.ThrowIfNull(param, "param is null");
			return await source.ToPageListAsync(param.PageIndex, param.PageSize);
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="pageSize">每页显示的数据条数</param>
		/// <returns></returns>
		public static PageModel<T> ToPageList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
		{
			ErrorHelper.ThrowIfNull(source, "source is null");
			if (pageIndex <= 0)
			{
				pageIndex = 1;
			}
			if (pageSize <= 0)
			{
				pageSize = 10;
			}
			int totalCount = source.Count<T>();
			if (pageIndex * pageSize > totalCount)
			{
				pageIndex = totalCount / pageSize;
				pageIndex += ((totalCount % pageSize == 0) ? 0 : 1);
				if (pageIndex < 1)
				{
					pageIndex = 1;
				}
			}
			if (totalCount > 0)
			{
				return new PageModel<T>(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<T>(), totalCount, pageIndex, pageSize);
			}
			return new PageModel<T>(new List<T>(), totalCount, pageIndex, pageSize);
		}

		/// <summary>
		/// 异步分页查询
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static async Task<PageModel<T>> ToPageListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
		{
			return await Task.FromResult(source.ToPageList(pageIndex, pageSize));
		}
	}
}
