using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace HotelBooking
{
    [ServiceContract]
    public interface IHotelBookingService
    {
        [OperationContract]
        BookingResponse BookHotel(Reservation reservation);
    }
}
