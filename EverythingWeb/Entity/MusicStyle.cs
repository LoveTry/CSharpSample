using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EverythingWeb.Entity
{
    public class MusicStyle
    {
        [Key]
        public virtual Guid StyleID { get; set; }
        public virtual string StyleName { get; set; }
    }
}