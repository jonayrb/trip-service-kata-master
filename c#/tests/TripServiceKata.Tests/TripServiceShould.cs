using FluentAssertions;
using TripServiceKata.Entity;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void get_trips_by_user()
        {
            var tripService = new TripService();
            User aGivenUser = new User();

            var trips = tripService.GetTripsByUser(aGivenUser);

            trips.Should().HaveCount(1);
        }
    }
}
