using System.Collections.Generic;

namespace Refactoring_RentalMovie
{
    public class Movie
    {
        public const int Children = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;
        private readonly string _title;
        private int _priceCode;

        private readonly Dictionary<int, IPrice> _moviePrices = new Dictionary<int, IPrice>
        {
            {Regular, new RegularPrice()},
            {NewRelease, new NewReleasePrice()},
            {Children, new ChildrenPrice()},
        };

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public void SetPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public string GetTitle()
        {
            return _title;
        }

        public double GetMovieCharge(int daysRented)
        {
            return _moviePrices[_priceCode].GetCharge(daysRented);
        }

        public int GetMovieFrequentRenterPoints(int daysRented)
        {
            return _moviePrices[_priceCode].GetFrequentRenterPoints(daysRented);
        }
    }
}