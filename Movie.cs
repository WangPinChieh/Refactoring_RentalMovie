namespace Refactoring_RentalMovie
{
    public class Movie
    {
        public const int Children = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;
        private readonly string _title;
        private int _priceCode;

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
            double result = 0;
            switch (GetPriceCode())
            {
                case Regular:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case NewRelease:
                    result += daysRented * 3;
                    break;
                case Children:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}