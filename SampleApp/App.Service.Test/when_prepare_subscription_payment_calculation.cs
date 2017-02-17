using App.Domain;
using NUnit.Framework;
using Moq;

namespace App.Service.Test
{
    [TestFixture]
    public class when_prepare_subscription_payment_calculation
    {
        SubscriptionPlan _subscriptionPlan;
        [SetUp]
        public void SetupTest()
        {
            _subscriptionPlan = new SubscriptionPlan();
            _subscriptionPlan.Level = SubscriptionLevel.Clinic;
            _subscriptionPlan.Term = SubscriptionTerm.Monthly;
        }
        [Test]
        public void then_PaymentStrategyFactory_GetStrategy_should_be_called()
        {
            // Arrange
            var mockPaymentStrategyFactory = new Mock<IPaymentStrategyFactory>();
            mockPaymentStrategyFactory.Setup(p => p.GetPaymentStratgey(It.IsAny<string>()));

            SubscriptionService subscriptionService = new SubscriptionService(mockPaymentStrategyFactory.Object);

            // Act
            subscriptionService.CalculatePayment(_subscriptionPlan);

            // Assert
            mockPaymentStrategyFactory.Verify(p => p.GetPaymentStratgey(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
