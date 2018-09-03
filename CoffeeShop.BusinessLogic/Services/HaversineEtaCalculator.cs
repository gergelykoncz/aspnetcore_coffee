using CoffeeShop.BusinessEntity.Dto;
using CoffeeShop.BusinessEntity.Enums;
using CoffeeShop.BusinessLogic.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CoffeeShop.BusinessLogic.Services
{
    public class HaversineEtaCalculator : IEtaCalculator
    {
        const double MILES_TO_METERS = 1609.34;
        const double EARTH_RADIUS_IN_KM = 6371.00;

        private double degreeToRadian(double degree)
        {
            return degree * (Math.PI / 180);
        }

        private double calculateDistance(Coordinates userCoordinates, Coordinates shopCoordinates)
        {
            var dLat = this.degreeToRadian(shopCoordinates.Latitude - userCoordinates.Latitude);
            var dLon = this.degreeToRadian(shopCoordinates.Longitude - userCoordinates.Longitude);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(this.degreeToRadian(userCoordinates.Latitude)) * Math.Cos(this.degreeToRadian(shopCoordinates.Latitude)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = EARTH_RADIUS_IN_KM * c;
            return d;

        }

        public async Task CalculateEta(Coordinates userCoordinates, Coordinates shopCoordinates, TransportationMode transportationMode)
        {
            throw new NotImplementedException();
        }
    }
}
