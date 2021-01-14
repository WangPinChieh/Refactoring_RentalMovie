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
            GivenRentals(new Rental(new Movie("RegularMovie 1", Movie.Regular), 10));
            StatementShouldBe(
                "Rental Record for Jay\n\tRegularMovie 1\t14\nAmount owed is 14\nYou earned 1 frequent renter points");
        }

        [Test]
        public void customer_rent_children_movie_10_days()
        {
            GivenRentals(new Rental(new Movie("Children 1", Movie.Children), 10));
            StatementShouldBe(
                "Rental Record for Jay\n\tChildren 1\t12\nAmount owed is 12\nYou earned 1 frequent renter points");
        }

        [Test]
        public void customer_rent_new_release_movie_10_days()
        {
            GivenRentals(new Rental(new Movie("NewRelease 1", Movie.NewRelease), 10));
            StatementShouldBe(
                "Rental Record for Jay\n\tNewRelease 1\t30\nAmount owed is 30\nYou earned 2 frequent renter points");
        }

        [Test]
        public void customer_rent_all_kind_of_movies()
        {
            GivenRentals(new Rental(new Movie("NewRelease 1", Movie.NewRelease), 10));
            GivenRentals(new Rental(new Movie("Children 1", Movie.Children), 4));
            GivenRentals(new Rental(new Movie("Regular 1", Movie.Regular), 17));
            StatementShouldBe(
                "Rental Record for Jay\n\tNewRelease 1\t30\n\tChildren 1\t3\n\tRegular 1\t24.5\nAmount owed is 57.5\nYou earned 4 frequent renter points");
        }

        private void GivenRentals(Rental rental)
        {
            _customer.AddRental(rental);
        }

        private void StatementShouldBe(string expected)
        {
            Assert.AreEqual(
                expected,
                _customer.Statement());
        }
    }
}