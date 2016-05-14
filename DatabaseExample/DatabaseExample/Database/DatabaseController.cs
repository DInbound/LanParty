using MySql.Data.MySqlClient;

namespace DatabaseExample.Database
{
    /// <summary>
    /// Abstract DB controller, derive from this class to reuse the connection
    /// </summary>
    public abstract class DatabaseController
    {
        protected MySqlConnection conn; //Can be used by derived classes

        /// <summary>Default constructor</summary>
        public DatabaseController()
        {
            //Fill in the correct info!
            conn = new MySqlConnection("Server=localhost;Database=lanparty;Uid=root;Pwd=root");
        }
    }
}
