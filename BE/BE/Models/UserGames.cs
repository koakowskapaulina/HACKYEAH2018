using System;

namespace BE.Models
{
    public class UserGames
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SelectedRoute { get; set; }
        public int RaffleCompatibilityLength { get; set; }

        public UserGames()
        {
        }

        public UserGames(long _ID, long _UserID, DateTime _CreatedDate, string _SelectedRoute)
        {
            ID = _ID;
            UserID = _UserID;
            CreatedDate = _CreatedDate;
            SelectedRoute = _SelectedRoute;
        }
    }
}
