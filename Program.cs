using System.Security.Cryptography;
//Defining variables
float distanceNumber;
float averageSpeedNumber;
float milesPerGallonNumber;
float gasCapacityNumber;
float costPerGallonNumber;
byte passengersNumber;
float songLengthNumber;
//Explanation to user
Console.WriteLine("We are going to map out a road trip for Fall Break. I'm going to ask you some specific questions about the trip, and then I'll calculate a trip summary from that information.");
//Location
Console.Write("Where will you be driving? ");
string location = Console.ReadLine();
//Driver
Console.Write("Who will be driving? ");
string driver = Console.ReadLine();
//Distance
Console.Write($"How many miles to get to {location}? ");
string distanceText = Console.ReadLine();
//Average speed
Console.Write($"What average speed (MPH) will {driver} be travelling? ");
string averageSpeedText = Console.ReadLine();
//Miles per gallon (MPG)
Console.Write("How many MPG does your car get?" );
string milesPerGallonText = Console.ReadLine();
//Gas capacity
Console.Write("How many gallons of gas does your car hold? ");
string gasCapacityText = Console.ReadLine();
//Passanger capacity
Console.Write("Excluding the driver, how many riders in the car? ");
string passengersText = Console.ReadLine();
//Currency
Console.Write("What unit of currency ($,£,¥,€) do you use? ");
string currency = Console.ReadLine();
//Cost per gallon
Console.Write($"What is the fuel price per gallon ({currency})? ");
string costPerGallonText = Console.ReadLine();
//Song length
Console.Write("What is the average song length(min)? ");
string songLengthText = Console.ReadLine();
//Calculate and Display Information
Console.WriteLine($"{"Driver:", -50} {driver}");
Console.WriteLine($"{"Currency:", -50} {currency}");

Console.WriteLine(); //Space

Console.WriteLine($"{"Distance (miles):", -50} {distanceText:#.##}");
Console.WriteLine($"{"Average Speed (mph):", -50} {averageSpeedText:#.##}");
bool distanceBool = float.TryParse(distanceText, out distanceNumber); //converting string to float
bool averageSpeedBool = float.TryParse(averageSpeedText, out averageSpeedNumber); //converting string to float
float drivingTimeHour = Convert.ToByte((distanceNumber -(distanceNumber % averageSpeedNumber))/averageSpeedNumber); //hours spent driving
float drivingTimeMinute = Convert.ToByte((distanceNumber/averageSpeedNumber - drivingTimeHour)*60); //minutes spent driving
Console.WriteLine($"{"Time Driving:", -50} {drivingTimeHour:#}H {drivingTimeMinute:#}M");

Console.WriteLine(); //Space

Console.WriteLine($"{"Vehicle Miles per Gallon:", -50} {milesPerGallonText}");
bool milesPerGallonBool = float.TryParse(milesPerGallonText, out milesPerGallonNumber); //converting string to float
float fuelNeeded = (distanceNumber / milesPerGallonNumber * 2); //calculates gas needed for a round trip
Console.WriteLine($"{"Fuel Needed (round trip):", -50} {fuelNeeded:#.00} gallons");
bool gasCapacityBool = float.TryParse(gasCapacityText, out gasCapacityNumber); //converting string to float
float rangePerTank = (milesPerGallonNumber*gasCapacityNumber); //calculates the amount of miles per tank
Console.WriteLine($"{"Range per Tank:", -50} {rangePerTank:#.00}");
byte fuelStops = Convert.ToByte(fuelNeeded/milesPerGallonNumber); //calculates the amount of stops needed to refill gas
Console.WriteLine($"{"Estimated Fuel Stops:", -50} {fuelStops}");

Console.WriteLine(); //Space

Console.WriteLine($"{"Gas Price per Gallon:",-50} {currency}{costPerGallonText}");
bool costPerGallonBool = float.TryParse(costPerGallonText, out costPerGallonNumber); //converting string to float
float fuelCost = (costPerGallonNumber * fuelNeeded); //calculates cost of fuel
Console.WriteLine($"{"Fuel Cost:",-50} {currency}{fuelCost:0.00}");
bool passengersBool = byte.TryParse(passengersText, out passengersNumber); //converting string to float
byte riders = passengersNumber += 1; //adds the driver and passengers
Console.WriteLine($"{"Riders (split):",-50} {riders}");
float costPerPerson = fuelCost / riders; //calculates the amount for fuel each person pays
Console.WriteLine($"{"Cost per Person:",-50} {currency}{costPerPerson:0.00} (+ Snacks)");
float costPerMile = fuelCost / distanceNumber; //calculates the cost of fuel per mile
Console.WriteLine($"{"Cost per Mile:",-50} {currency}{costPerMile:0.00}");
float costPerHour = fuelCost / (distanceNumber / averageSpeedNumber); //calculates the cost of fuel by the time spent driving
Console.WriteLine($"{"Cost per Hour:", -50} {currency}{costPerHour:0.00}");

Console.WriteLine(); //Space

Console.WriteLine($"{"Average song length (min):", -50} {songLengthText}");
bool songLengthBool = float.TryParse(songLengthText, out songLengthNumber); //converting string to float
short totalTimeDriving = (short)((drivingTimeHour * 60) + drivingTimeMinute);
float songsNeeded = (((totalTimeDriving - (totalTimeDriving % songLengthNumber)) / songLengthNumber) + (totalTimeDriving % songLengthNumber)); //calculates the amount of songs needed for the amount of time driving
Console.WriteLine($"{"Number of songs needed:", -50} {songsNeeded:#}");