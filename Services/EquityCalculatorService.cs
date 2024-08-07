using EquityCalculatorApi.Models;
using System;
using System.Collections.Generic;

namespace EquityCalculatorApi.Services
{
    public class EquityCalculatorService
    {
        public EquityCalculation CalculateEquity(decimal sellingPrice, DateTime reservationDate, int equityTerm)
        {
            var monthlyAmount = sellingPrice / equityTerm;
            var payments = new List<EquityPayment>();

            decimal balance = sellingPrice - monthlyAmount;
            DateTime dueDate = reservationDate.AddMonths(1);

            for (int term = 1; term <= equityTerm; term++)
            {
                var interest = 0.05m * balance;
                var insurance = 0.01m * monthlyAmount;
                var total = monthlyAmount + interest + insurance;

                payments.Add(new EquityPayment
                {
                    Balance = balance,
                    DueDate = DateTime.Parse(dueDate.ToString("yyyy-MM-dd")),
                    Term = term,
                    PaymentInfo = new PaymentInfo
                    {
                        Amount = monthlyAmount,
                        Interest = interest,
                        Insurance = insurance,
                        Total = total
                    }
                });

                balance -= monthlyAmount;
                dueDate = dueDate.AddMonths(1);
            }

            return new EquityCalculation
            {
                SellingPrice = sellingPrice,
                ReservationDate = reservationDate,
                EquityTerm = equityTerm,
                MonthlyAmount = monthlyAmount,
                Payments = payments
            };
        }
    }
}
