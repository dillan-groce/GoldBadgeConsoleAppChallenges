using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> Doors { get; set; }

        public Badge() { }
        public Badge(int id)
        {
            BadgeID = id;
        }
        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
