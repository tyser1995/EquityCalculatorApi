namespace EquityCalculatorApi.Models
{
    public class EquityCalculation
    {
        public decimal SellingPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EquityTerm { get; set; }
        public decimal MonthlyAmount { get; set; }
        public List<EquityPayment> Payments { get; set; }
    }

    public class EquityPayment
    {
        public decimal Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }

    public class PaymentInfo
    {
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public decimal Insurance { get; set; }
        public decimal Total { get; set; }
    }
}
