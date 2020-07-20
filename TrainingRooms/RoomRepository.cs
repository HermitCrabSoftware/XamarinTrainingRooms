using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingRooms
{
    public class RoomRepository
    {
        private List<TrainingRoom> _rooms =
            new List<TrainingRoom>
            {
                new TrainingRoom
                {
                    Id = 1,
                    Name = "Hermes",
                    Location = "Mercury",
                    NumberComputers = 1
                },
                new TrainingRoom
                {
                    Id = 2,
                    Name = "Aphrodite",
                    Location = "Venus",
                    NumberComputers = 2
                },
                new TrainingRoom
                {
                    Id = 3,
                    Name = "Terra",
                    Location = "Earth",
                    NumberComputers = 25
                },
                new TrainingRoom
                {
                    Id = 4,
                    Name = "Aeris",
                    Location = "Mars",
                    NumberComputers = 999
                }
            };

        public RoomRepository()
        {
        }

        public List<TrainingRoom> GetRooms()
        {
            return this._rooms;
        }

        public TrainingRoom GetRoom(int id)
        {
            return this._rooms.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
