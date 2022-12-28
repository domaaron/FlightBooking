using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
//using FlightBooking.Application.models;
using FlightBooking.models;

namespace FlightBooking.Application.Infrastructure;
public class FlightBookingContext : DbContext
{
    public FlightBookingContext(DbContextOptions opt) : base(opt) { }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    public DbSet<Baggage> Baggages=> Set<Baggage>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<FlightClass> FlightClasses => Set<FlightClass>();
    public DbSet<HandIn> HandIns => Set<HandIn>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Producer> Producers => Set<Producer>();
    public DbSet<ReviewedHandIn> ReviewedHandIns => Set<ReviewedHandIn>();

    public void Seed()
    {
        Randomizer.Seed = new Random(2145);

    }
}
