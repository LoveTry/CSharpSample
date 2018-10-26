using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EverythingWeb.Entity
{
    /// <summary>
    /// 自定义注解说明
    /// [Required] 必输项
    /// [StringLength(200,MinimumLength =3,ErrorMessage ="最大200，最小3")]
    /// [Display(Name = "演唱者",Order =10000)] Order默认从10000开始，升序排列
    /// [[ScaffoldColumn(false)]] 隐藏字段
    /// [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:c}")]自动格式字符串
    /// [DataType(DataType.Password)]显示的数据类型
    /// </summary>
    public class Musics
    {
        [Key]
        public virtual Guid ID { get; set; }
        [Display(Name = "歌曲名称")]
        public virtual string Name { get; set; }
        [MaxLength(20, ErrorMessage = "不允许超过20个字符。")]
        [Display(Name = "演唱者")]
        public virtual string Singer { get; set; }
        [Display(Name = "风格")]
        public virtual Guid StyleID { get; set; }
    }
}