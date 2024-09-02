using HotelRepoPatternAssignment.Models;

namespace HotelRepoPatternAssignment.Repository
{
    public interface IRoom
    {
        public IEnumerable<Room> GetAll();

        Room? GetRoom(int id);
        void AddRoom(Room r);
       Room UpdateRoom(int id, Room r);
        void DeleteRoom(Room r);
    }
}
