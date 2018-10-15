using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingWeb.Models
{
    public class Dragon : IMonster
    {
        private IWeapon _IWeapon;
        private const int PowerLevel = 100;

        public Dragon(IWeapon weapon)
        {
            _IWeapon = weapon;
        }

        public double Attack()
        {
            return PowerLevel * _IWeapon.Power();
        }

        public string MyWeapon()
        {
            return _IWeapon.MyName();
        }

        public string MyName()
        {
            return "巨龙";
        }
    }
}