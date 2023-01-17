using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
//using FlightBooking.Application.models;
using FlightBooking.models;
using FlightBooking.Application.models;

namespace FlightBooking.Application.infrastructure;
public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions opt) : base(opt) { }

    public DbSet<Airline> Airlines => Set<Airline>();
    public DbSet<AirlineEmployee> AirlineEmployees => Set<AirlineEmployee>();
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    public DbSet<Baggage> Baggages => Set<Baggage>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<ConfirmedBooking> ConfirmedBookings => Set<ConfirmedBooking>();
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<models.Person> Persons => Set<models.Person>();
    public DbSet<Producer> Producers => Set<Producer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<models.Person>().OwnsOne(p => p.Address);
        modelBuilder.Entity<Flight>().OwnsOne(f1 => f1.ArrivalAddress);
        modelBuilder.Entity<Flight>().OwnsOne(f2 => f2.DepartureAddress);

        modelBuilder.Entity<Booking>().HasAlternateKey(b => b.Guid);
        modelBuilder.Entity<Booking>().Property(b => b.Guid).ValueGeneratedOnAdd();

        modelBuilder.Entity<Booking>().HasDiscriminator(b => b.BookingType);
        modelBuilder.Entity<models.Person>().HasDiscriminator(p => p.PersonType);
    }

    public void Seed()
    {
        Randomizer.Seed = new Random(2145);

        var producer = new Faker<Producer>("de").CustomInstantiator(p => new Producer(
            name: p.Vehicle.Manufacturer()))
            .Generate(10)
            .ToList();
        Producers.AddRange(producer);
        SaveChanges();

        var airplane = new Faker<Airplane>("de").CustomInstantiator(a => new Airplane(
            name: a.Vehicle.Model(),
            producer: a.Random.ListItem(producer),
            seats: a.Random.Int(81, 853),
            maxBaggageWeight: a.Random.Double(23, 50)))
            .Generate(10)
            .ToList();
        Airplanes.AddRange(airplane);
        SaveChanges();

        var person = new Faker<models.Person>("de").CustomInstantiator(p => new models.Person(
            firstName: p.Person.FirstName,
            lastName: p.Person.LastName,
            ssn: p.Random.Int(100000000, 999999999),
            birthDate: p.Person.DateOfBirth,
            address: new Address(p.Address.Country(), p.Address.City()),
            tel: p.Phone.PhoneNumber(),
            email: p.Internet.Email()))
            .Generate(10)
            .ToList();
        Persons.AddRange(person);
        SaveChanges();

        var airline = new Faker<Airline>("de").CustomInstantiator(a => new Airline(
            name: a.Company.CompanyName()))
            .Generate(10)
            .ToList();
        Airlines.AddRange(airline);
        SaveChanges();

        var flight = new Faker<Flight>("de").CustomInstantiator(f => new Flight(
            departureTime: f.Person.DateOfBirth,
            arrivalTime: f.Person.DateOfBirth,
            destinationTime: f.Person.DateOfBirth,
            airplane: f.Random.ListItem(airplane),
            airline: f.Random.ListItem(airline),
            departureAddress: new Address(f.Address.Country(), f.Address.City()),
            arrivalAddress: new Address(f.Address.Country(), f.Address.City()),
            isActive: f.Random.Bool()))
            .Generate(10)
            .ToList();
        Flights.AddRange(flight);
        SaveChanges();
    }
}
