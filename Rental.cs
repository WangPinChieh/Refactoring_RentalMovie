namespace Refactoring_RentalMovie
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            return _movie.GetMovieCharge(_daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            int frequentRenterPoints = 1;
            if ((_movie.GetPriceCode() == Movie.NewRelease)
                &&
                _daysRented > 1) frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}