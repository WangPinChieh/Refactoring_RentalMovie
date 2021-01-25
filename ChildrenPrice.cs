namespace Refactoring_RentalMovie
{
    public class ChildrenPrice : IPrice
    {
        public ChildrenPrice()
        {
        }

        public double GetCharge(int daysRented)
        {
            var result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}