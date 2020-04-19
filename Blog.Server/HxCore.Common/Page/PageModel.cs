using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HxCore.Common
{
	/// <summary>
	/// 分页的实体类
	/// </summary>
	public class PageModel<T>
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PageModel()
		{
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="items">数据集合</param>
		/// <param name="totalCount">总条数</param>
		public PageModel(IEnumerable<T> items, int totalCount)
		{
			this.TotalCount = totalCount;
			this.Items = ((items != null) ? items.ToList<T>() : new List<T>());
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="items">数据集合</param>
		/// <param name="totalCount">总条数</param>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="pageSize">每页条数</param>
		public PageModel(List<T> items, int totalCount, int pageIndex, int pageSize)
		{
			this.TotalCount = totalCount;
			this.Items = items;
			this.PageIndex = pageIndex;
			this.PageSize = pageSize;
		}
		/// <summary>
		/// 页码
		/// </summary>
		public int PageIndex { get; set; }

		/// <summary>
		/// 每页数据的条数
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// 总数
		/// </summary>
		public int TotalCount { get; set; }

		/// <summary>
		/// 扩展数据
		/// </summary>
		public object ExtendData { get; set; }

		/// <summary>
		/// 数据
		/// </summary>
		public List<T> Items { get; set; }
	}
}
