using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    public class BasePageParam
    {
        /// <summary>
        /// 每页多少条数据
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 当前页码
        /// 默认从第一页开始
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 排序的键
        /// </summary>
        public string SortKey { get; set; }
        //
        // 摘要:
        //     0 正序 1倒序
        public SortTypeEnum SortType { get; set; }
    }

    public enum SortTypeEnum
    {
        /// <summary>
        /// 正序
        /// </summary>
        ASC = 0,
        /// <summary>
        /// 倒序
        /// </summary>
        DESC = 1
    }
}
