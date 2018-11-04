using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json; 

namespace SWApi
{

    /// <summary>
    /// Class for parse JSON response
    /// </summary>
    public class SWAJson
    {
        /// <summary>
        /// if exist store next page URL
        /// </summary>
        private string _nextPageURL = string.Empty;
        public string NextPageURL
        {
            get { return _nextPageURL; }
        }

        /// <summary>
        /// Translate JSON response to Ship Model
        /// </summary>
        /// <param name="jsonResponse">JSON response</param>
        /// <param name="distance">given distance</param>
        /// <returns>Ship names, number of stops for resupply</returns>
        public List<SWAModel.Ship> GetShipsAndDistances(string jsonResponse, string distance)
        {
            JsonSerializerSettings jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;

            //convert JSON string to Model
            SWAModel.JResponse swapis = JsonConvert.DeserializeObject<SWAModel.JResponse>(jsonResponse, jSetting);

            //if next page exist
            _nextPageURL = (swapis.Next != null) ? swapis.Next : string.Empty;

            //ships data (name, MGLT ...) are stored as collection in results "node"
            foreach (SWAModel.Ship ship in swapis.Results)
            {
                ship.jumps = SWAHellper.CalculateStopsForDestination(distance, ship.MGLT);
            }

            //list of ships characteristic and calculation
            return swapis.Results;
        }
    }
}