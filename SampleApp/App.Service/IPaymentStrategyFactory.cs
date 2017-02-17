namespace App.Service
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy GetPaymentStratgey(string name);
    }
}