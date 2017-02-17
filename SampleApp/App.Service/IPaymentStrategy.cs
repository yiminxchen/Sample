using App.Domain;

namespace App.Service
{
    public interface IPaymentStrategy
    {
        string Strategy { get; }
        double CalculatePayment(SubscriptionPlan subscriptionPlan);
    }
}