using Accommodations.Models;

namespace Accommodations.Commands;

public class SearchBookingsCommand(
    IBookingService bookingService,
    DateTime startDate,
    DateTime endDate,
    string categoryName)
    : ICommand
{
    public void Execute()
    {
        IEnumerable<Booking?> bookings = bookingService.SearchBookings(startDate, endDate, categoryName);
        if (bookings.Any())
        {
            //Добавил: startDate ---> startDate.Date, endDate ---> endDate.Date
            Console.WriteLine($"Found {bookings.Count()} bookings for category '{categoryName}' between {startDate.Date} and {endDate.Date}:");
            foreach (Booking? booking in bookings)
            {
                Console.WriteLine($"- Booking ID: {booking.Id}, User ID: {booking.UserId}");
            }
        }
        else
        {
            Console.WriteLine("No bookings found.");
        }
    }

    public void Undo()
    {
        Console.WriteLine($"Undo operation is not supported for {nameof(GetType)}.");
    }
}
