using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Entity {
    public class User : IUser {
        private readonly List<IUser> friends = new List<IUser>();

        public List<IUser> GetFriends() {
            return friends;
        }

        public void AddFriend(IUser user) {
            friends.Add(user);
        }

        public List<Trip> FindTripsByUser() {
            throw new DependendClassCallDuringUnitTestException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}