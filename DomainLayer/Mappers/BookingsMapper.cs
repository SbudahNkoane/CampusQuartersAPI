using CampusQuartersAPI.Dtos.Booking;
using CampusQuartersAPI.Models;

namespace CampusQuartersAPI.Mappers
{
    public static class BookingsMapper
    {
        public static BookingDto ToBookingDto(this AccommodationBooking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                AccommodaitonId = booking.AccommodationId,
                BookedAt = booking.BookedAt,
                IsTaken = booking.IsTaken,
                IsViewed = booking.IsViewed,
                StudentId = booking.StudentId,
                ViewDate = booking.ViewDate,
            };
        }
        public static AccommodationBooking ToBookingFromCreateDto(this CreateBookingDto createBookingDto)
        {
            return new AccommodationBooking
            {
                AccommodationId = createBookingDto.AccommodaitonId,
                BookedAt = createBookingDto.BookedAt,
                IsTaken = createBookingDto.IsTaken,
                IsViewed = createBookingDto.IsViewed,
                StudentId = createBookingDto.StudentId,
                ViewDate = createBookingDto.ViewDate,
            };
        }
    }
}
