using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingWeb.Models
{
    /// <summary>
    /// 武器接口
    /// </summary>
    public interface IWeapon
    {
        int Power();
        string MyName();
    }
}
