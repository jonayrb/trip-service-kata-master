using System.Collections.Generic;

namespace TripServiceKata.Entity
{
    public interface IUser
    {
        List<IUser> GetFriends();
        void AddFriend(IUser user);
        List<Trip> FindTripsByUser();
    }
}