using App.Domain;

namespace App.Service
{
    public class HospitalPaymentStrategy : PaymentStrategy, IPaymentStrategy
    {
        protected override double Price
        {
            get
            {
                return 99.99d;
            }
        }

        public string Strategy
        {
            get { return SubscriptionLevel.Hospital.ToString(); }
        }
        public override double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            return (int)subscriptionPlan.Term * Price;
        }
    }
}