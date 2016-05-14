using System;

namespace DatabaseExample.Models
{
    /// <summary>
    /// Student Model
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        public string StudentNaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public int? StudiePunten { get; set; }
        public Game Game { get; set; }
    }
}
