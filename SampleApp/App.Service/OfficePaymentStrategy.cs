using App.Domain;

namespace App.Service
{
    public class OfficePaymentStrategy : PaymentStrategy, IPaymentStrategy
    {
        protected override double Price
        {
            get
            {
                return 19.99d;
            }
        }

        public string Strategy
        {
            get { return SubscriptionLevel.Office.ToString(); }
        }
        public override double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            return (int)subscriptionPlan.Term * Price;
        }
    }
}