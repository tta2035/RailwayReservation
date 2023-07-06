using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Booking.DTO;
using RailwayReservation.Application.Common.Interfaces.Persistences;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RailwayReservation.Infranstructure.Persistance.Repository
{
    public class BookingRepository : GenericRepository<Domain.Booking.Booking, BookingResponse>, IBookingRepository
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IBookingStatusRepository _bookingStatusRepository;
        public BookingRepository(RailwayReservationDbContext context,
            ITicketRepository ticketRepository, IBookingStatusRepository bookingStatusRepository) : base(context)
        {
            _ticketRepository = ticketRepository;
            _bookingStatusRepository = bookingStatusRepository;
        }

        public override async Task<List<BookingResponse>> GetAll()
        {
            var result = await (from booking in table
                                join passenger in _context.Passengers on booking.PassengerId equals passenger.Id
                                join paymentMethod in _context.PaymentMethods on booking.PaymentMethodId equals paymentMethod.Id
                                select new BookingResponse()
                                {
                                    Id = booking.Id,
                                    PassengerId = booking.PassengerId,
                                    PassengerName = passenger.FullName,
                                    TotalFare = booking.TotalFare,
                                    TotalPayment = booking.TotalPayment,
                                    Status = booking.Status,
                                    PaymentTerm = booking.PaymentTerm,
                                    PaymentMethodId = booking.PaymentMethodId,
                                    PaymentMethodName = paymentMethod.PaymentMethodName,
                                    CancellationTime = booking.CancellationTime,
                                    CancellationFee = booking.CancellationFee,
                                    CancellationReason = booking.CancellationReason,
                                    Description = booking.Description,
                                    CreateBy = booking.CreateBy,
                                    CreateTime = booking.CreateTime,
                                    UpdateBy = booking.UpdateBy,
                                    UpdateTime = booking.UpdateTime,
                                    BookingTime = booking.BookingTime,
                                    UserId = booking.UserId,
                                    PaidAmount = booking.PaidAmount,
                                    PaidTime = booking.PaidTime,
                                    RefundAmount = booking.RefundAmount,
                                    RefundTime = booking.RefundTime,
                                    ListTicket = _ticketRepository.GetByBooking(booking.Id).Result,
                                    ListBookingStatus = _bookingStatusRepository.GetByBookingId(booking.Id).Result
                                }).ToListAsync();
            return result;
        }

        public async Task<BookingResponse> getBookingResponseById(Guid id)
        {
            var result = await GetAll();
            return result.Where(e => e.Id == id).Single();
        }
    }
}