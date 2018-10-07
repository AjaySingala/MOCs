using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelBooking;
using System.ServiceModel;

namespace ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IHotelBookingService> serviceFactory =
                new ChannelFactory<IHotelBookingService>
                (new BasicHttpBinding(),
                "http://localhost:8733/HotelBooking/HotelBookingHttp");

            IHotelBookingService proxy = serviceFactory.CreateChannel();

            Reservation reservation = new Reservation();

            reservation.HotelName = "HoteYA";

            reservation.GuestName = "John";

            reservation.NumberOfDays = 3;

            reservation.CheckinDate = DateTime.Now;

            BookingResponse response = proxy.BookHotel(reservation);

            Console.WriteLine
                ("Booking response: {0}, booking reference: {1}",
                response.IsApproved ? "Approved" : "Declined",
                response.BookingReference);

            Console.ReadLine();
        }
    }
}
