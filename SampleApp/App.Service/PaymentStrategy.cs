using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public abstract class PaymentStrategy
    {
        protected abstract double Price { get; }

        public abstract double CalculatePayment(SubscriptionPlan subscriptionPlan);
    }
}
