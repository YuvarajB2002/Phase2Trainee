using HotelRepoPatternAssignment.Models;

namespace HotelRepoPatternAssignment.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetAll();

        Hotel? GetHotel(int id);
        void AddHotel(Hotel h);
       Hotel UpdateHotel(int id, Hotel h);
        void DeleteHotel(Hotel h);
    }
}
