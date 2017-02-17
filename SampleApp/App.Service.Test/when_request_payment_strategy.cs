using System;
using NUnit.Framework;
using App.Domain;

namespace App.Service.Test
{
    [TestFixture(SubscriptionLevel.Trial, typeof(TrialPaymentStrategy))]
    [TestFixture(SubscriptionLevel.Office, typeof(OfficePaymentStrategy))]
    [TestFixture(SubscriptionLevel.Clinic, typeof(ClinicPaymentStrategy))]
    [TestFixture(SubscriptionLevel.Hospital, typeof(HospitalPaymentStrategy))]
    public class when_request_payment_strategy
    {
        private SubscriptionLevel _subscriptionLevel;
        private Type _paymentStrategyResult;

        public when_request_payment_strategy(SubscriptionLevel subscriptionLevel, Type paymentStrategyResult)
        {
            _subscriptionLevel = subscriptionLevel;
            _paymentStrategyResult = paymentStrategyResult;
        }
        [Test]
        public void it_should_return_correct_payment_strategy()
        {
            IPaymentStrategyFactory subscriptionPaymentStrategyFactory = new SubscriptionPaymentStrategyFactory();

            IPaymentStrategy paymentStrategy = subscriptionPaymentStrategyFactory.GetPaymentStratgey(_subscriptionLevel.ToString());

            Assert.IsInstanceOf(_paymentStrategyResult, paymentStrategy);
        }
    }
}
