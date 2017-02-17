using NUnit.Framework;
using App.Domain;


namespace App.Service.Test
{
    [TestFixture(SubscriptionLevel.Trial, SubscriptionTerm.Monthly, 0d)]
    [TestFixture(SubscriptionLevel.Office, SubscriptionTerm.Quarterly, 59.97d)]
    [TestFixture(SubscriptionLevel.Clinic, SubscriptionTerm.Yearly, 479.88d)]
    [TestFixture(SubscriptionLevel.Hospital, SubscriptionTerm.Monthly, 99.99d)]
    public class when_calculate_subscription_payment
    {
        private SubscriptionLevel _subscriptionLevel;
        private SubscriptionTerm _subscriptionTerm;
        private double _paymentResult;

        public when_calculate_subscription_payment(SubscriptionLevel subscriptionLevel, SubscriptionTerm subscriptionTerm, double paymentResult)
        {
            _subscriptionLevel = subscriptionLevel;
            _subscriptionTerm = subscriptionTerm;
            _paymentResult = paymentResult;
        }

        [Test]
        public void it_should_return_correct_payment_on_subscription_level_and_term()
        {
            SubscriptionPlan subscriptionPlan = new SubscriptionPlan();
            subscriptionPlan.Level = _subscriptionLevel;
            subscriptionPlan.Term = _subscriptionTerm;

            IPaymentStrategyFactory paymentStrategyFactory = new SubscriptionPaymentStrategyFactory();
            SubscriptionService subscriptionService = new SubscriptionService(paymentStrategyFactory);
            var payment = subscriptionService.CalculatePayment(subscriptionPlan);

            Assert.AreEqual(_paymentResult, payment);
        }
    }
}
