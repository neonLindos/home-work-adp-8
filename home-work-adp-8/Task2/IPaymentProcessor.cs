using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home_work_adp_8.Task2
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }
}
