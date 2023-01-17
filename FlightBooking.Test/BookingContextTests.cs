using FlightBooking.models;
using Microsoft.EntityFrameworkCore;
using FlightBooking.Application.infrastructure;

namespace FlightBooking.Test
{
    [Collection("Sequential")]
    public class BookingContextTests
    {
        private BookingContext GetDatabase(bool deleteDb = false)
        {
            var db = new BookingContext(new DbContextOptionsBuilder()
                .UseSqlite("Data Source = FlightBooking.db")
                .UseLazyLoadingProxies()
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
            db.Seed();
        }
    }
}