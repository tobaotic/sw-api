using System;
using System.Collections.Generic;
using System.Text;

namespace SWApi
{
    public static class SWAHellper
    {

        /// <summary>
        /// Check if string is integer greater then 0
        /// </summary>
        /// <param name="intToBe">String to check</param>
        /// <returns> true if string is number greater then zero</returns>
        public static bool IsStringPositiveInteger(string intToBe)
        {
            int parseStrToInt = 0;
            Int32.TryParse(intToBe, out parseStrToInt);

            return (parseStrToInt >  0);
        }

        /// <summary>
        /// For given destination return number of stops for resupply 
        /// </summary>
        /// <param name="distanceMGLT">Distance length</param>
        /// <param name="shipMGLT">Ship distance per one tank</param>
        /// <returns>Number of stops for resupply</returns>
        public static string CalculateStopsForDestination(string distanceMGLT, string shipMGLT)
        {
            string retString = "Can not calculate number of stops!";

            bool convertDist = IsStringPositiveInteger(distanceMGLT);
            bool convertMGLT = IsStringPositiveInteger(shipMGLT);

            if (convertDist && convertMGLT)
            {
                int idistanceMGLT;
                Int32.TryParse(distanceMGLT, out idistanceMGLT);

                int iShipMGLT;
                Int32.TryParse(shipMGLT, out iShipMGLT);

                int modulo = idistanceMGLT % iShipMGLT;

                if (modulo == 0)
                {
                    retString = ((idistanceMGLT / iShipMGLT) - 1).ToString();
                }
                else
                {
                    retString = (idistanceMGLT / iShipMGLT).ToString();
                }
            }

            return retString;
        }
    }
}