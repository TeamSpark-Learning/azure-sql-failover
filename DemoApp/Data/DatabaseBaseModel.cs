namespace DemoApp.Data
{
    public abstract class DatabaseBaseModel
    {
        protected string _connectionString;

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}