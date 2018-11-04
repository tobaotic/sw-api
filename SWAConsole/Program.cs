using System;
using System.Collections.Generic;
using System.Text;

using SWApi;

namespace SWAConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class :: get JSON response for given URL
            SWARequest CSWARequest = new SWARequest();
            //Class :: parse JSON response
            SWAJson CSWAJson = new SWAJson();

            //result data for display
            List<SWAModel.Ship> ships = new List<SWAModel.Ship>();

            string pathURL = "https://swapi.co/api/starships/";

            //Show message for user input
            Console.WriteLine(string_all.InputEnterNumber);
            //wait for it ...
            string distance = Console.ReadLine();

            //check if input is valid integer greater then zero
            if (SWAHellper.IsStringPositiveInteger(distance))
            {
                //only ten rows per call
                while (pathURL != string.Empty)
                {
                    try
                    {
                        //get JSON response for API call
                        string jsonResponse = CSWARequest.GetJsonResponse(pathURL);
                        //parse response into ships 
                        ships.AddRange(CSWAJson.GetShipsAndDistances(jsonResponse, distance));

                        //check if there is another page to call
                        pathURL = CSWAJson.NextPageURL;
                    }
                    catch (Exception ex)
                    {
                        //something is wrong
                        Console.WriteLine(ex.Message);
                        pathURL = string.Empty;
                    }
                }

                //results are here
                foreach (SWAModel.Ship ship in ships)
                {
                    Console.WriteLine(string.Format("{0}: {1}", ship.name, ship.jumps));
                }
            }
            else
            {
                //input is not integer
                Console.WriteLine(string_all.WarningEnterNumber);
            }

            Console.ReadLine();
        }
    }
}