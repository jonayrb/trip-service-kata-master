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
            IUser aGivenUser = new User();
            IUser loggedUser = new User();
            var tripService = new TripService(loggedUser);
            aGivenUser.AddFriend(loggedUser);

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(1);
        }
    }
}
