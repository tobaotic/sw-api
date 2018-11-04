# SWApi project

## Main task
Class project responsible for retrieving and parsing the JSON response from [Star Wars API](https://swapi.co/api/starships/).

JSON response for starship URL endpoint will return values *(October 2018)*:
| Attribute | Value | Description |
| ------ | ------ | ------ |
| count | int | contains the number of all ships |
| next | string | next page URL |
| previous | string | previous page URL
| results | array | ship attributes |

More info about Star Wars [starship](https://swapi.co/documentation#starships) endpoint.

After the deserialization of result data it will calculate and return a list of Ship model.
 
## SWAModel Class
Used for JSON deserialization.

There is no need for deserialization of all attributes in JSON response so in selected models we use only attributes that are used in the calculation.

### JResponse
Deserialize the JSON string response from starships endpoint.

### Ship
| Attribute | Value | Description |
| ------ | ------ | ------ |
| name | string | ship name |
| MGLT | string | distance ship can reach |
| jumps | string | number of stops for resupply |
 
First two atributes represent data from JSON response, but third attribute **jumps** is used for calculating how many stops for resupply ship need for a given distance. 
 
## SWARequest Class
Class used for reading the JSON response.

### GetJsonResponse
**jsonAPIPath**: URL for HTTP requests
**returns**: JSON string

If retrieving of data for given URL is successful method will return JSON string. 
In case of any error (wrong URL, wrong REST endpoint, etc ...) it will throw an error exception.

## SWAJson Class
Main class which methods are used for calculation.
For JSON parsing as third party tool use [Json.NET](https://www.newtonsoft.com/json), *JSON framework for .NET*

### GetShipsAndDistances
**jsonResponse**: JSON string retrived from "GetJsonResponse" method
**distance**: distance (MGLT) for calculation
**returns**: list of Ship model

Parse JSON response and calculate the number of stops for each ship in the collection.
If JSON data hold URL for next page it will be saved in **NextPageURL** attribute.

## SWAHelper Class
Static class for calculation and other methods used in other class. 

### IsStringPositiveInteger
**intToB**e: string representation of integer
Check if input string is an integer greater than zero.

### CalculateStopsForDestination
**distanceMGLT**: how far will ship travel
**shipMGLT**: ships capability to travel with one tank

For specified ship reach (in MGLT) returns number of stops for resupply.

## Example of usage
Empty Ship list
```
List<SWAModel.Ship> ships = new List<SWAModel.Ship>();
```
Get JSON response from URL
```
string jsonResponse = CSWARequest.GetJsonResponse(pathURL);
```
Parse JSON and get ship data for specified distance
```
ships.AddRange(CSWAJson.GetShipsAndDistances(jsonResponse, distance));
```