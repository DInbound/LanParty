using System;

namespace DatabaseExample.Models
{
    /// <summary>
    /// Genre Model
    /// </summary>
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Verslavend { get; set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Verslavend ? "Verslavend" : "Niet verslavend");
        }
    }
}
