using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata {
    public class TripService {
        private readonly IUser loggedUser;

        public TripService(IUser getLoggedUser) {
            loggedUser = getLoggedUser;
        }

        public List<Trip> GetTripsByUser(IUser user) {
            List<Trip> tripList = new List<Trip>();
            ThrowsUserNotLoggedIn();

            var isFriend = LoggerUserIsFriend(user);

            if (isFriend) {
                tripList = user.FindTripsByUser();
            }

            return tripList;
        }

        private bool LoggerUserIsFriend(IUser user)
        {
            var isFriend = false;
            foreach (User friend in user.GetFriends())
            {
                if (!friend.Equals(loggedUser)) continue;
                isFriend = true;
                break;
            }

            return isFriend;
        }

        private void ThrowsUserNotLoggedIn()
        {
            if (loggedUser == null) throw new UserNotLoggedInException();
        }
    }
}