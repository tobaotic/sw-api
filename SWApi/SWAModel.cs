using System;
using System.Collections.Generic;
using System.Text;

namespace SWApi
{
    public class SWAModel
    {

        /// <summary>
        /// Convert JSON response string to model
        /// </summary>
        public class JResponse
        {
            //json response - next page url
            public string Next { get; set; }
            //json response - list of SW ships
            public List<Ship> Results;

        }

        /// <summary>
        /// Model for SW ships
        /// </summary>
        public class Ship
        {
            public string name { get; set; }
            public string MGLT { get; set; }
            public string jumps { get; set; }
        }
    }
}