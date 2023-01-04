using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
//using FlightBooking.Application.models;
using FlightBooking.models;
using FlightBooking.Application.models;

namespace FlightBooking.Application.Infrastructure;
public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions opt) : base(opt) { }
    
    public DbSet<Airline> Airlines => Set<Airline>();
    public DbSet<AirlineEmployee> AirlineEmployees => Set<AirlineEmployee>();    
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    public DbSet<Baggage> Baggages=> Set<Baggage>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<ConfirmedBooking> ConfirmedBookings => Set<ConfirmedBooking>();
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Producer> Producers => Set<Producer>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Passenger>().OwnsOne(p => p.Address);
        modelBuilder.Entity<Flight>().OwnsOne(f1 => f1.ArrivalAddress);
        modelBuilder.Entity<Flight>().OwnsOne(f2 => f2.DepartureAddress);

        modelBuilder.Entity<Booking>().HasAlternateKey(b => b.Guid);
        modelBuilder.Entity<Booking>().Property(b => b.Guid).ValueGeneratedOnAdd();

        modelBuilder.Entity<Booking>().HasDiscriminator(b => b.BookingType);
        modelBuilder.Entity<Passenger>().HasDiscriminator(p => p.PassengerType);
    }
}
