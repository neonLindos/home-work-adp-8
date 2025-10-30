using System;

namespace home_work_adp_8.Task1
{
    public abstract class Beverage
    {
        public string Description { get; protected set; } = "Неизвестный напиток";
        public virtual string GetDescription() => Description;
        public abstract decimal Cost();

        public virtual void Prepare()
        {
            Console.WriteLine($"Готовлю {Description}...");
        }
    }

    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;
        public BeverageDecorator(Beverage beverage) => _beverage = beverage;

        public override string GetDescription() => _beverage.GetDescription();
        public override decimal Cost() => _beverage.Cost();
        public override void Prepare() => _beverage.Prepare();
    }

    // === Напитки ===
    public class Espresso : Beverage
    {
        public Espresso() => Description = "Эспрессо";
        public override decimal Cost() => 1200m;  // 1200 ₸
        public override void Prepare() => Console.WriteLine("Готовлю эспрессо: молю зёрна, варю под давлением...");
    }

    public class Tea : Beverage
    {
        public Tea() => Description = "Чай";
        public override decimal Cost() => 800m;   // 800 ₸
        public override void Prepare() => Console.WriteLine("Завариваю ароматный чай...");
    }

    // === Добавки ===
    public class Milk : BeverageDecorator
    {
        public Milk(Beverage b) : base(b) { }
        public override string GetDescription() => _beverage.GetDescription() + ", Молоко";
        public override decimal Cost() => _beverage.Cost() + 200m;  // +200 ₸
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(Beverage b) : base(b) { }
        public override string GetDescription() => _beverage.GetDescription() + ", Сахар";
        public override decimal Cost() => _beverage.Cost() + 50m;   // +50 ₸
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(Beverage b) : base(b) { }
        public override string GetDescription() => _beverage.GetDescription() + ", Взбитые сливки";
        public override decimal Cost() => _beverage.Cost() + 350m;  // +350 ₸
    }
}