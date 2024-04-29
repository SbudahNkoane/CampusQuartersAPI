using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Booking;
using CampusQuartersAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly CampusQuartersDataContext _dataContext;

        public BookingsController(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _dataContext.Bookings.Include(b => b.Accommodation).ToList();
            var bookingsDto = bookings.Select(b => b.ToBookingDto());
            return Ok(bookingsDto);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = _dataContext.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking.ToBookingDto());
        }

        [HttpPut]
        [Route("{bookingId:int}")]
        public IActionResult UpdateBooking([FromRoute]int bookingId, [FromBody]UpdateBookingDto updateBookingDto)
        {
           var booking = _dataContext.Bookings.FirstOrDefault(bk=> bk.Id == bookingId);
            if (booking == null)
            {
                return BadRequest();
            }
            booking.IsTaken = updateBookingDto.IsTaken;
            booking.IsViewed = updateBookingDto.IsViewed;
            booking.ViewDate = updateBookingDto.ViewDate;

            _dataContext.SaveChanges();
            return Ok(booking.ToBookingDto());
        }

        [HttpPost]
        [Route("{studentId}/{accommodationId}")]
        public IActionResult PostBooking([FromRoute] int studentId, [FromRoute] int accommodationId)
        {
            var student = _dataContext.Students.FirstOrDefault(x => x.Id == studentId);
            var accommodation = _dataContext.Accommodations.FirstOrDefault(x => x.Id == accommodationId);
            if (student == null || accommodation == null)
            {
                return BadRequest();
            }

            CreateBookingDto createBookingDto = new()
            {
                AccommodaitonId = accommodationId,
                StudentId = studentId
            };

            _dataContext.Bookings.Add(createBookingDto.ToBookingFromCreateDto());
            _dataContext.SaveChanges();
            return Ok(createBookingDto);
        }
    }
}
