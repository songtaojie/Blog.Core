using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HxCore.Model
{
    [Table("JobInfo")]
    [Serializable]
    public class JobInfo : Base.BaseEntity
    {
        /// <summary>
        /// 职位
        /// </summary>
        [StringLength(100)]
        public string Position
        {
            get; set;
        }
        /// <summary>
        /// 行业
        /// </summary>
        [StringLength(100)]
        public string Industry
        {
            get; set;
        }
        /// <summary>
        /// 工作单位
        /// </summary>
        [StringLength(100)]
        public string WorkUnit
        {
            get; set;
        }
        /// <summary>
        /// 工作年限
        /// </summary>
        public int WorkYear
        {
            get; set;
        }

        /// <summary>
        /// 目前状态
        /// </summary>
        [StringLength(20)]
        public string Status
        {
            get; set;
        }
        /// <summary>
        /// 熟悉的技术
        /// </summary>
        [StringLength(1000)]
        public string Skills
        {
            get; set;
        }
        /// <summary>
        /// 擅长的领域
        /// </summary>
        [StringLength(1000)]
        public string GoodAreas
        {
            get; set;
        }
    }
}
