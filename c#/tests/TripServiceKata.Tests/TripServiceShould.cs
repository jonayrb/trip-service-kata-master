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
            User aGivenUser = new User();
            var loggedUser = aGivenUser;
            var tripService = new TripService(loggedUser);

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(1);
        }
    }
}
