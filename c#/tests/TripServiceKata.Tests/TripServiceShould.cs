using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using FluentAssertions;
using NSubstitute;
using TripServiceKata.Entity;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void get_trips_by_user()
        {
            IUser aGivenUser = NSubstitute.Substitute.For<IUser>();
            var aGivenUserTrips = new List<Trip>(){new Trip()};
            aGivenUser.FindTripsByUser().Returns(aGivenUserTrips);
            IUser loggedUser = new User();
            var tripService = new TripService(loggedUser);
            aGivenUser.GetFriends().Returns(new EditableList<IUser>() { loggedUser });

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(1);
        }
    }
}
