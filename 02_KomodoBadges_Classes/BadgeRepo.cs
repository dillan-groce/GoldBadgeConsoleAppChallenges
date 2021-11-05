﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Classes
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _repo = new Dictionary<int, List<string>>();
        public bool AddBadge(Badge badge)
        {
            int startingCount = _repo.Count;
            _repo.Add(badge.BadgeID, badge.Doors);
            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _repo;
        }
        public Badge GetABadgeByID(int badgeid)
        {
            if (_repo.ContainsKey(badgeid))
            {
                Badge badge = new Badge(badgeid);
                badge.Doors = _repo[badgeid];
                return badge;
            }
            return null;
        }
        public bool UpdateExistingBadge(int oldBadgeID, Badge newBadge)
        {
            Badge oldBadge = GetABadgeByID(oldBadgeID);
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
                return true;
            }
            else { return false; }
        }
        public bool DeleteBadge(Badge badge)
        {
            bool deleteBadge = _repo.Remove(badge.BadgeID);
            return deleteBadge;
        }
    }
}
