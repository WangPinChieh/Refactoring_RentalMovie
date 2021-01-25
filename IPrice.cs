namespace Refactoring_RentalMovie
{
    public interface IPrice
    {
        double GetCharge(int daysRented);
        int GetFrequentRenterPoints(int daysRented);
    }
}