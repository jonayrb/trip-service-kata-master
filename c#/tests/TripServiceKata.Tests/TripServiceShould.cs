using Castle.Components.DictionaryAdapter;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using TripServiceKata.Entity;
using Xunit;

namespace TripServiceKata.Tests {
    public class TripServiceShould
    {
        [Fact]
        public void get_trips_by_user_when_logged_user_is_friend()
        {
            IUser loggedUser = new User();
            var tripService = new TripService(loggedUser);
            var aGivenUser = AGivenUserWithFriend(loggedUser);

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(1);
        }

        [Fact]
        public void not_returns_trips_when_logged_user_has_not_friends()
        {
            IUser loggedUser = new User();
            var tripService = new TripService(loggedUser);
            var otherUserThanLoggedUser = new User();
            var aGivenUser = AGivenUserWithFriend(otherUserThanLoggedUser);

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(0);
        }

        private static IUser AGivenUserWithFriend(IUser loggedUser)
        {
            IUser aGivenUser = Substitute.For<IUser>();
            var aGivenUserTrips = new List<Trip>() { new Trip() };
            aGivenUser.FindTripsByUser().Returns(aGivenUserTrips);
            aGivenUser.GetFriends().Returns(new EditableList<IUser>() { loggedUser });
            return aGivenUser;
        }
    }
}
