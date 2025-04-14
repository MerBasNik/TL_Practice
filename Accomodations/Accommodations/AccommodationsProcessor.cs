using System.Globalization;
using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];

        switch (commandName)
        {
            //Вынес реализацию кажждой команды в отдельный метод
            case "book":
                ProcessCommandBook(parts);
                break;
            case "cancel":
                ProcessCommandCancel(parts);
                break;
            case "undo":
                ProcessCommandUndo(parts);
                break;
            case "find":
                ProcessCommandFind(parts);
                break;
            case "search":
                ProcessCommandSearch(parts);
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }

    private static void ProcessCommandBook(string[] parts)
    {
        if (parts.Length != 6)
        {
            Console.WriteLine("Invalid number of arguments for booking.");
            return;
        }

        // Проверка на правильность валюты
        bool isParsedCurrency = Enum.TryParse(typeof(CurrencyDto), parts[5], true, out object? currency);
        if (!isParsedCurrency)
        {
            throw new ArgumentException($"Invalid currency: {parts[5]}");
        }

        //Проверка на правильность введенной даты
        DateTime startDate = DateParsing(parts[3]);
        DateTime endDate = DateParsing(parts[4]);

        //Получаю начало и конец брони, проверяю, что начало раньше конца брони
        if (startDate >= endDate)
        {
            throw new ArgumentException("End date cannot be earlier than start date");
        }

        //Изменил DateTime.Now ---> DateTime.Today
        if (startDate < DateTime.Today)
        {
            throw new ArgumentException("Start date cannot be earlier than now date");
        }

        //Проверка на правильность введенного Id
        bool isParsedUserId = int.TryParse(parts[1], out int userId);
        if (!isParsedUserId)
        {
            throw new ArgumentException($"Invalid user id: {parts[1]}");
        }

        //Заменил значения parts[0/1/../5] на переменные
        BookingDto bookingDto = new()
        {
            UserId = userId,
            Category = parts[2],
            StartDate = startDate,
            EndDate = endDate,
            Currency = (CurrencyDto)currency,
        };

        BookCommand bookCommand = new(_bookingService, bookingDto);
        bookCommand.Execute();
        _executedCommands.Add(++s_commandIndex, bookCommand);
        Console.WriteLine("Booking command run is successful.");
    }

    private static void ProcessCommandCancel(string[] parts)
    {
        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid number of arguments for canceling.");
            return;
        }

        Guid bookingId = GuidParsing(parts[1]);
        CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
        cancelCommand.Execute();
        _executedCommands.Add(++s_commandIndex, cancelCommand);
        Console.WriteLine("Cancellation command run is successful.");
    }

    private static void ProcessCommandUndo(string[] parts)
    {
        //Проверка на наличие команд в истории
        if (_executedCommands.Count == 0)
        {
            throw new ArgumentException("No booking commands have been executed.");
        }

        _executedCommands[s_commandIndex].Undo();
        _executedCommands.Remove(s_commandIndex);
        s_commandIndex--;
        Console.WriteLine("Last command undone.");
    }

    private static void ProcessCommandFind(string[] parts)
    {
        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
            return;
        }

        Guid id = GuidParsing(parts[1]);
        FindBookingByIdCommand findCommand = new(_bookingService, id);
        findCommand.Execute();
        //Добавил команду в историю
        _executedCommands.Add(++s_commandIndex, findCommand);
    }

    private static void ProcessCommandSearch(string[] parts)
    {
        if (parts.Length != 4)
        {
            Console.WriteLine(
                "Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
            return;
        }

        DateTime startDate = DateParsing(parts[1]);
        DateTime endDate = DateParsing(parts[2]);
        string categoryName = parts[3];
        SearchBookingsCommand searchCommand = new(_bookingService, startDate, endDate, categoryName);
        searchCommand.Execute();
        //Добавил команду в историю
        _executedCommands.Add(++s_commandIndex, searchCommand);
    }

    //Добавил метод парсинга даты, чтобы использовать DateParsing в нескольких местах
    private static DateTime DateParsing(string dateString)
    {
        bool isParsedDateStr = DateTime.TryParse(dateString, out DateTime dateParsed);
        if (!isParsedDateStr)
        {
            throw new ArgumentException($"Invalid enddate: {dateString}. Формат должен быть таким DD/MM/YYYY");
        }
        return dateParsed;
    }

    //Добавил метод парсинга Guid Id, чтобы использовать GuidParsing в нескольких местах
    private static Guid GuidParsing(string guidString)
    {
        bool isParsedGuid = Guid.TryParse(guidString, out Guid guidParsed);
        if (!isParsedGuid)
        {
            throw new ArgumentException($"Invalid guid: {guidString}");
        }
        return guidParsed;
    }
}
