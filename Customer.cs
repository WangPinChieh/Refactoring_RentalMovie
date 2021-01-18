using System.Collections.Generic;

namespace Refactoring_RentalMovie
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (var rental in _rentals)
            {
                Rental each = rental;

                frequentRenterPoints += each.GetFrequentRenterPoints();
                totalAmount += each.GetCharge();
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          each.GetCharge() + "\n";
            }

            result += "Amount owed is " + totalAmount +
                      "\n";
            result += "You earned " + frequentRenterPoints
                                    +
                                    " frequent renter points";
            return result;
        }
    }
}