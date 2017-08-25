﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enroute.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;
        }

        public void AddStop(string tripName, Stop stop)
        {
            var trip = GetTripByName(tripName);
            if(trip != null)
            {
                trip.Stops.Add(stop);
                _context.Stops.Add(stop);
            }
                
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .Where(t => t.Name == tripName)
                .FirstOrDefault();
        }

        public IEnumerable<Trip> GetTripsByUsername(string name)
        {
            return _context.
                    Trips.
                    Include(t=>t.Stops).
                    Where(t => t.UserName == name).
                    ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
          return  (await _context.SaveChangesAsync()) > 0;
        }
    }
}
