using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home_work_adp_8.Task2
{
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[PayPal] Оплата {amount:N0} ₸ прошла успешно!");
        }
    }

    public class StripePaymentService
    {
        public bool MakeTransaction(decimal totalAmount)
        {
            Console.WriteLine($"[Stripe] Транзакция на {totalAmount:N0} ₸ выполнена.");
            return true;
        }
    }
    public class SquarePaymentGateway
    {
        public string Charge(decimal price, string currency = "KZT")
        {
            return $"[Square] Платёж {price:N0} {currency} принят.";
        }
    }

    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentGateway _square;

        public SquarePaymentAdapter(SquarePaymentGateway square)
        {
            _square = square;
        }

        public void ProcessPayment(decimal amount)
        {
            string result = _square.Charge(amount);
            Console.WriteLine(result);
        }
    }
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripe;

        public StripePaymentAdapter(StripePaymentService stripe)
        {
            _stripe = stripe;
        }

        public void ProcessPayment(decimal amount)
        {
            _stripe.MakeTransaction(amount);
        }
    }
}
