using App.Domain;

namespace App.Service
{
    public class UnknownPaymentStrategy : PaymentStrategy, IPaymentStrategy
    {
        protected override double Price
        {
            get
            {
                return -1.0d;
            }
        }
        public string Strategy
        {
            get { return string.Empty; }
        }
        public override double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            return Price;
        }
    }
}