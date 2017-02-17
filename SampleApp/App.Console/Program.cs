using App.Domain;
using App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentStrategyFactory subscriptionPaymentStrategyFactory = new SubscriptionPaymentStrategyFactory();

            IPaymentStrategy paymentStrategy = subscriptionPaymentStrategyFactory.GetPaymentStratgey("Trial");

            System.Console.ReadLine();
        }
    }
}
