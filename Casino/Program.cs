PrintTitle();
Console.Write("Ваш баланс: ");
Console.WriteLine();
double balans = Convert.ToDouble((Console.ReadLine()));
double multiplicator = 2d;
Random random = new();
bool isPlay = true;

while (isPlay)
{
    Console.WriteLine("Введите ставку");
    double bet = Convert.ToDouble(Console.ReadLine());

    int randDigit = random.Next(1, 20);

    balans -= bet;
    if (randDigit > 1)
    {
        balans += bet;
        double winSum = bet * (1 + multiplicator * randDigit % 17);
        balans += winSum;
        Console.WriteLine("Вы выиграли");
    }
    else
    {
        Console.WriteLine("Вы проиграли");
    }

    Console.WriteLine($"Ваш баланс {balans}");
    Console.WriteLine("Вы хотите продолжить? (да/нет)");
    string decision = Console.ReadLine().ToLower();
    if (decision == "нет" || balans <= 0)
    {
        isPlay = false;
    }
}

static void PrintTitle()
{
    Console.WriteLine(" ##     ##     ###  #  #     #   ### ");
    Console.WriteLine("#  #   #  #   #     #  # #   #  #   #");
    Console.WriteLine("#      ####   ####  #  #  #  #  #   #");
    Console.WriteLine("#  #   #  #      #  #  #   # #  #   #");
    Console.WriteLine(" ##    #  #   ###   #  #     #   ### ");
}