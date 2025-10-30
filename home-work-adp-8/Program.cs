// See https://aka.ms/new-console-template for more information
using home_work_adp_8.Task1;
using home_work_adp_8.Task2;

Console.WriteLine("Hello, World!");

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;


void TestTask1()
{
    Console.WriteLine("=== Тест 1: Эспрессо с добавками ===");

    Beverage order = new Espresso();

    order.Prepare();

    // Цены в тенге
    Console.WriteLine($"{order.GetDescription()} = {order.Cost():F0} ₸");

    order = new Milk(order);
    order = new Sugar(order);
    order = new WhippedCream(order);

    Console.WriteLine($"{order.GetDescription()} = {order.Cost():F0} ₸");
}

void TestTask2()
{
    Console.WriteLine("=== Паттерн Адаптер: Платежные системы ===\n");

    var orders = new[] { 15000m, 8900m, 25000m };

    TestPayment(new PayPalPaymentProcessor(), orders[0]);
    TestPayment(new StripePaymentAdapter(new StripePaymentService()), orders[1]);
    TestPayment(new SquarePaymentAdapter(new SquarePaymentGateway()), orders[2]);

    Console.WriteLine("\nВсе платежи обработаны через IPaymentProcessor!");
}

void TestPayment(IPaymentProcessor processor, decimal amount)
{
    processor.ProcessPayment(amount);
}


TestTask1();
TestTask2();