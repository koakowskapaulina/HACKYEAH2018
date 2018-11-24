using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Models
{
    public class UserGames
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SelectedRoutes { get; set; }

        public UserGames()
        {
        }

        public UserGames(long _ID, long _UserID, DateTime _CreatedDate, string _SelectedRoutes)
        {
            ID = _ID;
            UserID = _UserID;
            CreatedDate = _CreatedDate;
            SelectedRoutes = _SelectedRoutes;
        }
    }
}
