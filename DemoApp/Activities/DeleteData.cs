using System.Threading;
using DemoApp.Activities.Base;
using DemoApp.Data;

namespace DemoApp.Activities
{
    public class DeleteData : DataActivityBase<DatabaseWriteModel>
    {
        public DeleteData(string connectionString, Mutex mutex, int cursorRow, int cursorColumn, int timeoutSec) :
            base(connectionString, mutex, cursorRow, cursorColumn, timeoutSec)
        {
        }
        
        protected override string GetResultFromDatabase(DatabaseWriteModel database)
        {
            database.DeleteAddresses();
            return "+";
        }
    }
}