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
                double thisAmount = 0;
                Rental each = rental;
                //determine amounts for each line
                thisAmount = amountFor(each);

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease)
                    &&
                    each.GetDaysRented() > 1) frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount +
                      "\n";
            result += "You earned " + frequentRenterPoints
                                    +
                                    " frequent renter points";
            return result;
        }

        private static double amountFor(Rental rental)
        {
            double result = 0;
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (rental.GetDaysRented() > 2)
                        result += (rental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    result += rental.GetDaysRented() * 3;
                    break;
                case Movie.Children:
                    result += 1.5;
                    if (rental.GetDaysRented() > 3)
                        result += (rental.GetDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}