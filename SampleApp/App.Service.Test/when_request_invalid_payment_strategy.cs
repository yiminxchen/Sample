using NUnit.Framework;

namespace App.Service.Test
{
    [TestFixture("")]
    [TestFixture("Personal")]
    public class when_request_invalid_payment_strategy
    {
        private string _strategyName;

        public when_request_invalid_payment_strategy(string name)
        {
            _strategyName = name;
        }

        [Test]
        public void it_should_return_unknown_payment_strategy()
        {
            IPaymentStrategyFactory subscriptionPaymentStrategyFactory = new SubscriptionPaymentStrategyFactory();

            IPaymentStrategy paymentStrategy = subscriptionPaymentStrategyFactory.GetPaymentStratgey(_strategyName);

            Assert.IsInstanceOf(typeof(UnknownPaymentStrategy), paymentStrategy);
        }
    }
}
