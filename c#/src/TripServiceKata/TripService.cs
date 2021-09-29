using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata {
    public class TripService {
        private readonly IUser loggedUser;

        public TripService(IUser getLoggedUser) {
            loggedUser = getLoggedUser;
        }

        public List<Trip> GetTripsByUser(IUser user) {
            List<Trip> tripList = new List<Trip>();
            bool isFriend = false;
            ThrowsUserNotLoggedIn();

            foreach (User friend in user.GetFriends()) {
                if (friend.Equals(loggedUser)) {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend) {
                tripList = user.FindTripsByUser();
            }

            return tripList;

        }

        private void ThrowsUserNotLoggedIn()
        {
            if (loggedUser == null) throw new UserNotLoggedInException();
        }
    }
}