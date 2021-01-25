namespace Refactoring_RentalMovie
{
    public class NewReleasePrice : IPrice
    {
        public NewReleasePrice()
        {
        }

        public double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}