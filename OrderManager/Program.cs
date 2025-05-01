namespace OrderManager
{  
    public class Program
    {
        struct Order
        {
            public string Product;
            public int Count;
            public string Name;
            public string Address;
            public DateOnly Date;
        }

        public static void Main()
        {
            Console.WriteLine("Order Manager");
            Order order = new Order();
            bool isRight = false;
            const int daysDelivery = 3;
            order.Date = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Сегодня: {order.Date}");

            while (!isRight)
            {
                order.Product = ReadAndWriteInfo("Введите название товара: ");
                do
                {
                    string countStr = ReadAndWriteInfo("Введите количество товара: ");
                    bool countParsed = int.TryParse(countStr, out order.Count);
                    if (!countParsed)
                    {
                        Console.WriteLine("Ошибка! Введите число");
                    }
                } while (!countParsed);

                order.Name = ReadAndWriteInfo("Введите имя пользователя: ");
                order.Address = ReadAndWriteInfo("Введите адрес доставки: ");

                isRight = OrderConfirmation(order);
            }

            static bool OrderConfirmation(Order order)
            {
                string answer = ReadAndWriteInfo($"Здравствуйте, {order.Name}, вы заказали {order.Count} {order.Product} на адрес {order.Address}, все верно? ");
                if (answer.ToLower() == "да")
                {
                    Console.WriteLine($"{order.Name}! Ваш заказ {order.Product} в количестве {order.Count} оформлен! Ожидайте доставку по адресу {order.Address} к {order.Date.AddDays(daysDelivery)}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Попробуйте ввести данные ещё раз");
                    return false;
                }
            }

            static string ReadAndWriteInfo(string param)
            {
                Console.Write(param);
                string input = Console.ReadLine();
                return input;
            }
        }
    }
}