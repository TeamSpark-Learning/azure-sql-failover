using System;
using System.Threading;
using DemoApp.Activities.Base;
using DemoApp.Data;
using DemoApp.Data.Model;

namespace DemoApp.Activities
{
    public class WriteData : DataActivityBase<DatabaseWriteModel>
    {
        public WriteData(string connectionString, Mutex mutex, int cursorRow, int cursorColumn, int timeoutSec) :
            base(connectionString, mutex, cursorRow, cursorColumn, timeoutSec)
        {
        }

        protected override string GetResultFromDatabase(DatabaseWriteModel database)
        {
            var address = new Address
            {
                AddressLine1 = "Dniprovske hw",
                City = "Kyiv",
                StateProvince = "Kyiv area",
                CountryRegion = "Ukraine",
                PostalCode = "01001",
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.UtcNow
            };
            
            database.AddAddress(address);

            return "+";
        }
    }
}