using FlightBooking.models;
using FlightBooking.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Test
{
    [Collection("Sequential")]
    public class BookingContextTests
    {
        private BookingContext GetDatabase(bool deleteDb = false)
        {
            var db = new BookingContext(new DbContextOptionsBuilder()
                .UseSqlite("Data Source = FlightBooking.db")
                .Options);
            if (deleteDb)
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            return db;
        }

        [Fact]
        public void CreateDatabaseSuccessTest()
        {
            using var db = GetDatabase(deleteDb: true);
        }

        [Fact]
        public void SeedDatabaseTest()
        {
            using var db = GetDatabase(deleteDb: true);
        }
    }
}