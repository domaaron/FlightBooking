﻿using FlightBooking.Application.infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Test
{
    public class DatabaseTest : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly BookingContext _db;

        public DatabaseTest()
        {
            _connection = new SqliteConnection("DataSource=FlightBooking.db");
            _connection.Open();
            var opt = new DbContextOptionsBuilder()
                .UseSqlite(_connection)  // Keep connection open (only needed with SQLite in memory db)
                .UseLazyLoadingProxies()
                .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .Options;

            _db = new BookingContext(opt);
        }
        public void Dispose()
        {
            _db.Dispose();
            _connection.Dispose();
        }
    }
}
