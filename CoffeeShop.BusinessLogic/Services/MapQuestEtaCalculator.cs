using CoffeeShop.BusinessEntity.Dto;
using CoffeeShop.BusinessEntity.Enums;
using CoffeeShop.BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CoffeeShop.BusinessLogic.Services
{
    public class MapQuestEtaCalculator : IEtaCalculator
    {
        /// <summary>
        /// Calculates the estimated time of arrival in seconds
        /// </summary>
        /// <param name="userCoordinate">The current coordinates of the user</param>
        /// <param name="shopCoordinate">The coordinates of the shop</param>
        /// <param name="transportationMode">The selected mode of transportation</param>
        /// <returns>ETA in seconds</returns>
        public async Task<int> CalculateEta(Coordinates userCoordinate, Coordinates shopCoordinate, TransportationMode transportationMode)
        {
            string apiKey = Environment.GetEnvironmentVariable("MAPQUEST_API_KEY");
            string encodedUser = this.urlEncodeCoordinates(userCoordinate);
            string encodedShop = this.urlEncodeCoordinates(shopCoordinate);
            string transport = null;
            switch (transportationMode)
            {
                case TransportationMode.Bicycle:
                    transport = "bicycle ";
                    break;
                case TransportationMode.Car:
                    transport = "fastest";
                    break;
                case TransportationMode.Foot:
                    transport = "pedestrian";
                    break;
                case TransportationMode.PublicTransport:
                    throw new NotImplementedException("Public transport not supported by MapQuest");
            }

            string url = string.Format("https://www.mapquestapi.com/directions/v2/route?key={0}&from={1}&to={2}&outFormat=json&routeType={3}", apiKey, encodedUser, encodedShop, transport);


            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            var response = JsonConvert.DeserializeObject<MapQuestResponse>(data);
                            return response.Route.Time;
                        }
                        else
                        {
                            throw new InvalidOperationException("Invalid response from Mapquest");
                        }
                    }
                }
            }
        }

        private string urlEncodeCoordinates(Coordinates coordinates)
        {
            return HttpUtility.UrlEncode(string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude));
        }
    }
}
