using System;

namespace DatabaseExample.Models
{
    /// <summary>
    /// Game Model
    /// </summary>
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }

        public override string ToString()
        {
            return String.Format("{0} (id = {1}) {2}", Name, ID, Genre);
        }
    }
}
