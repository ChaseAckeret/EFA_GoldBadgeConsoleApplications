using System;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
namespace Badges
{
    class BadgesRepo
    {
        private Dictionary<int, List<string>> _accessList = new Dictionary<int, List<string>>();

        //Create
        public void AddToAccessList(Badge badge)
        {

            _accessList.Add(badge.BadgeID, badge.Doors);
        }

        //Read
        public Dictionary<int, List<string>> GetAccessList()
        {
            return _accessList;
        }

        //Update
        public bool UpdateAccessList(int id, string newDoor, string oldDoor)
        {
            foreach (KeyValuePair<int, List<string>> badge in _accessList)
            {
                if (badge.Key == id)
                {
                    List<string> doors = badge.Value;
                    for (int i = 0; i < doors.ToArray().Length; ++i)
                    {
                        if (oldDoor == doors[i])
                        {
                            doors[i] = newDoor;
                            doors.ToList();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Delete
        public bool DeleteAccessList(int id, string oldDoor)
        {
            foreach(KeyValuePair<int, List<string>> badge in _accessList)
            {
                if (badge.Key == id)
                {
                    List<string> doors = badge.Value;
                    for (int i = 0; i < doors.ToArray().Length; i++)
                    {
                        if (oldDoor == doors[i])
                        {
                            doors.RemoveAt(i);
                            doors.ToList();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Helper Method
        public Badge GetBadgeById(int id)
        {
            Badge returnBadge = new Badge();
            foreach (KeyValuePair<int, List<string>> badge in _accessList)
            {
                if(badge.Key == id)
                {
                    returnBadge.BadgeID = id;
                    returnBadge.Doors = badge.Value;
                    return returnBadge;
                }
            }
            return null;
        }
    }
}
