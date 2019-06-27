using System.Collections.Generic;

namespace BlazingPizza.Client
{
    public class OrderState
    {
        public bool showingConfigureDialog { get; private set; }

        public Pizza configuringPizza { get; private set; }

        public Order Order { get; private set; } = new Order();
        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            configuringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            showingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            configuringPizza = null;
            showingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(configuringPizza);
            configuringPizza = null;

            showingConfigureDialog = false;
        }

        public void RemoveConfiguredPizza(Pizza configuredPizza)
        {
            Order.Pizzas.Remove(configuredPizza);
        }
        public void ResetOrder()
        {
            Order = new Order();
        }

    }
}