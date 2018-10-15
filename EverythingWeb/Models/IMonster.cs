using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingWeb.Models
{
    /// <summary>
    /// 怪物接口
    /// </summary>
    public interface IMonster
    {
        /// <summary>
        /// 怪物攻击
        /// </summary>
        double Attack();

        string MyWeapon();

        string MyName();
    }
}