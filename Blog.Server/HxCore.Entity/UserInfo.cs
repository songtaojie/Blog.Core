using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HxCore.Common;

namespace HxCore.Entity
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    [Table("UserInfo")]
    [Serializable]
    public class UserInfo : BaseModel, IEntity<string>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [StringLength(100)]
        public string Id
        {
            get; set;
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string UserName
        {
            get; set;
        }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(40)]
        public string PassWord
        {
            set;
            get;
        }
        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength(100)]
        public string NickName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Email
        {
            set; get;
        }
        /// <summary>
        /// 第三方登录唯一标识
        /// </summary>
        [StringLength(80)]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Lock { set; get; } = "N";
        /// <summary>
        /// 头像存储文件路径
        /// </summary>
        [StringLength(500)]
        public string AvatarUrl
        {
            get; set;
        }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        [NotMapped]
        public bool IsAdmin => Helper.IsYes(Admin);
        /// <summary>
        /// 是否是管理员
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Admin
        {
            get; set;
        } = "N";
        /// <summary>
        /// 是否激活
        /// </summary>
        [NotMapped]
        public bool IsActivate => Helper.IsYes(Activate);

        /// <summary>
        /// 是否激活
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Activate
        {
            get; set;
        } = "N";
        /// <summary>
        /// 用户注册时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime RegisterTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否被删除,假删除，数据库中还有记录
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Delete { get; set; } = "N";

        /// <summary>
        /// 删除时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 使用MarkDown编辑器
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string UseMdEdit { get; set; } = "N";
        /// <summary>
        /// 登录的ip
        /// </summary>
        [StringLength(100)]
        public string LoginIp { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public virtual DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 基础信息
        /// </summary>
        [StringLength(100)]
        public string BasicInfoId { get; set; }

        /// <summary>
        /// 工作信息
        /// </summary>
        [StringLength(100)]
        public string JobInfoId { get; set; }
    }
}
