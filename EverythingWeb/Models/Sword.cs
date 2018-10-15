using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingWeb.Models
{
    public class Sword : IWeapon
    {
        public string Name { get; }
        public Sword(string name)
        {
            Name = name;
        }
        public int Power()
        {
            return 10;
        }

        public string MyName()
        {
            return Name;
        }
    }
}