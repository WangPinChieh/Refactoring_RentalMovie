using NUnit.Framework;

namespace Refactoring_RentalMovie
{
    public class RentalMovieTests
    {
        [SetUp]
        public void SetUp()
        {
            _customer = new Customer("Jay");
        }

        private Customer _customer;

        [Test]
        public void customer_rent_regular_movie_10_days()
        {
            _customer.AddRental(new Rental(new Movie("RegularMovie 1", Movie.Regular), 10));
            Assert.AreEqual(
                "Rental Record for Jay\n\tRegularMovie 1\t14\nAmount owed is 14\nYou earned 1 frequent renter points",
                _customer.Statement());
        }
    }
}