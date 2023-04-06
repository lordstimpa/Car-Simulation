using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biltävlingen.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal DistanceTraveled { get; set; }
        public decimal Speed { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public Car (int id, string model, decimal distance, decimal speed, TimeSpan? finishtime)
        {
            Id = id;
            Model = model;
            DistanceTraveled = distance;
            Speed = speed;
            FinishTime = finishtime;
        }
    }
}
