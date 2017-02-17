using App.Domain;

namespace App.Service
{
    public class TrialPaymentStrategy : PaymentStrategy, IPaymentStrategy
    {
        protected override double Price
        {
            get
            {
                return 0.0d;
            }
        }

        public string Strategy
        {
            get { return SubscriptionLevel.Trial.ToString(); }
        }
        public override double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            return (int)subscriptionPlan.Term * Price;
        }
    }
}