using App.Domain;

namespace App.Service
{
    /// <summary>
    /// Implement Subscription related services
    /// </summary>
    public class SubscriptionService
    {
        private IPaymentStrategyFactory _paymentStrategyFactory;

        public SubscriptionService(IPaymentStrategyFactory paymentStrategyFactory)
        {
            _paymentStrategyFactory = paymentStrategyFactory;
        }

        /// <summary>
        /// Calculate subscription payment based on subscription level and term
        /// </summary>
        /// <param name="subscriptionPlan">customer's subscription plan</param>
        /// <returns>subscription payment customer should pay</returns>
        public double CalculatePayment(SubscriptionPlan subscriptionPlan)
        {
            IPaymentStrategy paymentStrategy =  _paymentStrategyFactory.GetPaymentStratgey(subscriptionPlan.Level.ToString());

            if (paymentStrategy == null)
            {
                return -1d;
            }

            return paymentStrategy.CalculatePayment(subscriptionPlan);
        }
    }
}