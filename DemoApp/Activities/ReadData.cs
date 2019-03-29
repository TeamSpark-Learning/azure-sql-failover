using System.Threading;
using DemoApp.Activities.Base;
using DemoApp.Data;

namespace DemoApp.Activities
{
    public class ReadData : DataActivityBase<DatabaseReadModel>
    {
        public ReadData(string connectionString, Mutex mutex, int cursorRow, int cursorColumn, int timeoutSec)
            : base(connectionString, mutex, cursorRow, cursorColumn, timeoutSec)
        {
        }

        protected override string GetResultFromDatabase(DatabaseReadModel database)
        {
            return database.GetAddressesCount().ToString();
        }
    }
}