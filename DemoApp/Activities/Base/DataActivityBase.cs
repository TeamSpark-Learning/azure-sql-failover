using System;
using System.Threading;
using DemoApp.Data;

namespace DemoApp.Activities.Base
{
    public abstract class DataActivityBase<T> where T : DatabaseBaseModel, new()
    {
        private readonly string _connectionString;
        private readonly Mutex _mutex;
        private readonly int _cursorRow;
        private readonly int _cursorColumn;
        private readonly int _timeoutSec;

        protected DataActivityBase(string connectionString, Mutex mutex, int cursorRow, int cursorColumn, int timeoutSec)
        {
            _connectionString = connectionString;
            _mutex = mutex;
            _cursorRow = cursorRow;
            _cursorColumn = cursorColumn;
            _timeoutSec = timeoutSec;
        }

        protected abstract string GetResultFromDatabase(T database);
        
        public void Start()
        {
            var database = new T();
            database.SetConnectionString(_connectionString);
            
            var result = "?";
            
            PrintResult(result);

            while (true)
            {
                result = "?";
                
                if (_timeoutSec > 0)
                {
                    PrintResult(result);
                }

                try
                {
                    result = GetResultFromDatabase(database);
                }
                catch (Exception ex)
                {
                    result = "-";
                }
                
                PrintResult(result);
                
                Thread.Sleep(TimeSpan.FromSeconds(_timeoutSec));
            }
        }

        private void PrintResult(string result)
        {
            _mutex.WaitOne();

            Console.CursorTop = _cursorRow;
            Console.CursorLeft = _cursorColumn;
            Console.WriteLine(result.PadRight(5));

            _mutex.ReleaseMutex();
        }
    }
}