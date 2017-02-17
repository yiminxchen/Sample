using App.Domain;

namespace App.Service
{
    public class ClinicPaymentStrategy : PaymentStrategy, IPaymentStrategy
    {
        protected override double Price
        {
            get
            {
                return 39.99d;
            }
        }

        public string Strategy
        {
            get { return SubscriptionLevel.Clinic.ToString(); }
        }
        public override double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            return (int)subscriptionPlan.Term * Price;
        }
    }
}