using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace App.Service
{
    /// <summary>
    /// Implementation of the SubscriptionPaymentStrategyFactory
    /// </summary>
    public class SubscriptionPaymentStrategyFactory : IPaymentStrategyFactory
    {
        private IList<IPaymentStrategy> _paymentStrategy = new List<IPaymentStrategy>();

        public SubscriptionPaymentStrategyFactory()
        {
        }

        /// <summary>
        /// Find the IPaymentStrategy that matches the name
        /// </summary>
        /// <param name="name">The name of the IPaymentStrategy to search</param>
        /// <returns>IPaymentStrategy interface</returns>
        public IPaymentStrategy GetPaymentStratgey(string name)
        {
            if (_paymentStrategy.Count() == 0)
            {
                CreatePaymentStrategy();
            }

            IPaymentStrategy obj = _paymentStrategy.FirstOrDefault(s => s.Strategy == name);

            if (obj == null)
            {
                return new UnknownPaymentStrategy();
            }

            return obj;
        }

        /// <summary>
        /// Create all IPaymentStrategy instance in the assembly
        /// </summary>
        private void CreatePaymentStrategy()
        {
            Type[] typesInAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInAssembly)
            {
                if (type.GetInterface(typeof(IPaymentStrategy).ToString()) != null)
                {
                    _paymentStrategy.Add(Activator.CreateInstance(type) as IPaymentStrategy);
                }
            }
        }
    }
}