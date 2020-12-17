using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public enum EventType
    {
        Golf =1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outings
    {
        public EventType TypeOfEvent { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outings() { }
        public Outings(EventType typeOfEvent, int attendance, DateTime date, decimal costPerPerson, decimal totalCost)
        {
            TypeOfEvent = typeOfEvent;
            Attendance = attendance;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }
    }
}
