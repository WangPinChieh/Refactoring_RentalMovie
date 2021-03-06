﻿using System.Collections.Generic;
using System.Linq;

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
            string result = "Rental Record for " + GetName() + "\n";

            result = _rentals.Aggregate(result,
                (current, rental) =>
                    current + ("\t" + rental.GetMovie().GetTitle() + "\t" + rental.GetCharge() + "\n"));

            result += "Amount owed is " + GetTotalAmount() +
                      "\n";
            result += "You earned " + GetTotalFrequentRenterPoints()
                                    +
                                    " frequent renter points";
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            return _rentals.Sum(each => each.GetFrequentRenterPoints());
        }

        private double GetTotalAmount()
        {
            return _rentals.Sum(each => each.GetCharge());
        }
    }
}