using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private GarageManager myGarage;

        public void ExecutePrograms()
        {
            myGarage = new GarageManager();
            executeUserProgramSelection();
        }

        private enum eUserChoice
        {
            InsertNewVehicle = 1,
            DisplayListOfVehicles = 2,
            UpdateVehicleStatus = 3,
            InflateTiresToMaximum = 4,
            RefuelVehicle = 5,
            ChargeElectricVehicle = 6,
            DisplayVehicleInformation = 7,
            Abort = 8
        }

        private static void showMainMenu()
        {
            string mainMenu = string.Format(
@"Welcome to our garage !!!
Please choose which program you want to run:
1. Insert a new Vehicle into the Garage
2. Display a list of license numbers currently in the garage
3. Change a certain vehicle’s status
4. Inflate tires to maximum
5. Refuel a fuel - based vehicle
6. Charge an electric - based vehicle
7. Display vehicle information
8. Exit");
            Console.WriteLine(mainMenu);
        }

        private static eUserChoice retrieveUserProgramSelection()
        {
            string userInput;
            eUserChoice eUserChoice;

            showMainMenu();
            userInput = Console.ReadLine();
            try
            {
                eUserChoice = (eUserChoice)int.Parse(userInput);
            }
            catch
            {
                Console.WriteLine("Illegal input");
                return retrieveUserProgramSelection();
            }

            return eUserChoice;
        }

        private void executeUserProgramSelection()
        {
            eUserChoice eUserChoice = eUserChoice.InsertNewVehicle;
            while (eUserChoice != eUserChoice.Abort)
            {
                eUserChoice = retrieveUserProgramSelection();
                switch (eUserChoice)
                {
                    case eUserChoice.InsertNewVehicle:
                        insertNewVehicle();
                        break;
                    case eUserChoice.DisplayListOfVehicles:
                        displayLicenseOfVehiclesInTheGarage();
                        break;
                    case eUserChoice.UpdateVehicleStatus:
                        updateVehicleStatusInGarage();
                        break;
                    case eUserChoice.InflateTiresToMaximum:
                        inflateTiresToMaximum();
                        break;
                    case eUserChoice.ChargeElectricVehicle:
                        chargeVehicle();
                        break;
                    case eUserChoice.RefuelVehicle:
                        refuelVehicle();
                        break;
                    case eUserChoice.DisplayVehicleInformation:
                        displayVehicleInformation();
                        break;
                }
            }
        }

        private static void showEngineTypeMenu()
        {
            string engineMenu = string.Format(
@"What type of engine is in your vehicle:
1. Fuel Based Engine
2. Electric Based Engine ");
            Console.WriteLine(engineMenu);
        }

        private static eEngineBased retrieveEngineTypeFromUser()
        {
            string inputFromUser;
            eEngineBased eEngineBased;

            showEngineTypeMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eEngineBased = (eEngineBased)int.Parse(inputFromUser);
            }
            catch
            {
                Console.WriteLine("Illegal input please try again");
                return retrieveEngineTypeFromUser();
            }

            return eEngineBased;
        }

        private static void showFuelBasedVehiclesMenu()
        {
            string vehicleType = string.Format(
@"please choose type of vehicle:
1. Car
2. Motorcycle 
3. Truck");
            Console.WriteLine(vehicleType);
        }

        private static void showElectricBasedVehiclesMenu()
        {
            string vehicleType = string.Format(
@"please choose type of vehicle:
1. Car
2. Motorcycle");
            Console.WriteLine(vehicleType);
        }

        private static eVehicleType retrieveVehicelType(eEngineBased eEngineBased)
        {
            string inputFromUser;
            eVehicleType eVehicleType;
            int vehicleType;

            if (eEngineBased == eEngineBased.Electricty)
            {
                showElectricBasedVehiclesMenu();
            }
            else
            {
                showFuelBasedVehiclesMenu();
            }

            inputFromUser = Console.ReadLine();
            try
            {
                vehicleType = int.Parse(inputFromUser);
                eVehicleType = (eVehicleType)vehicleType;
            }
            catch
            {
                Console.WriteLine("Illegal input:");
                return retrieveVehicelType(eEngineBased);
            }

            if (eEngineBased == eEngineBased.Electricty && vehicleType != 1 && vehicleType != 2)
            {
                Console.WriteLine("You can either choose 1 or 2:");

                return retrieveVehicelType(eEngineBased);
            }

            return eVehicleType;
        }

        private static string getVehicleModelFromUser()
        {
            Console.WriteLine("Please enter model number:");
            string inputModelFromUser = Console.ReadLine();

            return inputModelFromUser;
        }

        private void newCustomer(out string o_CustomerName, out string o_CustomerPhone)
        {
            o_CustomerName = getCustomerNameFromUser();
            o_CustomerPhone = getCustomerPhoneFromUser();
        }

        private static bool isOnlyLetters(string inputString)
        {
            bool isValidInput = true;
            foreach (char c in inputString)
            {
                if (!char.IsLetter(c))
                {
                    isValidInput = false;
                    break;
                }
            }

            return isValidInput;
        }

        private static string getCustomerNameFromUser()
        {
            bool isValidFirstName;
            bool isValidLastName;
            bool isValidInput = false;
            string inputStringFromUser = string.Empty;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter your full name \n");
                inputStringFromUser = Console.ReadLine();
                string[] firstAndLastName = inputStringFromUser.Split(' ');
                if (firstAndLastName.Length == 2)
                {
                    isValidFirstName = isOnlyLetters(firstAndLastName[0]);
                    isValidLastName = isOnlyLetters(firstAndLastName[1]);
                    isValidInput = isValidFirstName && isValidLastName;
                    if (isValidInput)
                    {
                        break;
                    }

                }

                Console.WriteLine("The input you entered is invalid. Please try again.\n");
            }

            return inputStringFromUser;
        }

        private static string getCustomerPhoneFromUser()
        {
            bool isValidInput = true;

            while (true)
            {
                if (!isValidInput)
                {
                    Console.WriteLine("The input you entered is invalid. Please try again.\n");
                }

                Console.WriteLine("Please enter 10 digit cell phone number");
                string inputNumberFromUser = Console.ReadLine();
                isValidInput = int.TryParse(inputNumberFromUser, out int o_CustomerPhoneNumber);
                if (isValidInput && inputNumberFromUser.Length == 10 && inputNumberFromUser[0] == '0')
                {
                    return inputNumberFromUser;
                }

                isValidInput = false;
            }
        }

        private void insertNewVehicle()
        {
            string o_VehicleNumberFromUser = getLicenceNumberFromUser();
            string o_CustomerName, o_CustomerPhone;
            eEngineBased eEngineBased;
            eVehicleType eVehicleType;
            bool isVehicleNewInGarage = true;
            Dictionary<string, object> i_vehicleProperties = new Dictionary<string, object>();

            if (o_VehicleNumberFromUser == "e" || o_VehicleNumberFromUser == "E")
            {
                return;
            }

            try
            {
                isVehicleNewInGarage = myGarage.InsertVehicle(o_VehicleNumberFromUser);
            }
            catch (VehicleNotInGarageException)
            {
                while (true)
                {
                    eEngineBased = retrieveEngineTypeFromUser();
                    switch (eEngineBased)
                    {
                        case eEngineBased.FuelBased:
                        case eEngineBased.Electricty:
                            break;
                    }

                    break;
                }

                i_vehicleProperties.Add("EngineBased", eEngineBased);
                i_vehicleProperties.Add("ModelName", getVehicleModelFromUser());
                i_vehicleProperties.Add("LicenceNumber", o_VehicleNumberFromUser);

                while (true)
                {
                    eVehicleType = retrieveVehicelType(eEngineBased);

                    switch (eVehicleType)
                    {
                        case eVehicleType.Car:
                            i_vehicleProperties.Add("VehicleType", eVehicleType);
                            i_vehicleProperties.Add("NumOfDoors", retrieveNumberOfDoors());
                            i_vehicleProperties.Add("Color", retrieveColor());
                            break;
                        case eVehicleType.Motorcycle:
                            i_vehicleProperties.Add("VehicleType", eVehicleType);
                            i_vehicleProperties.Add("EngineVolume", getEngineVolume());
                            i_vehicleProperties.Add("LicenseType", retrieveLicenceType());
                            break;
                        case eVehicleType.Truck:
                            i_vehicleProperties.Add("VehicleType", eVehicleType);
                            i_vehicleProperties.Add("IsHavingDangerousMetrials", checkIfDangerousMaterials());
                            i_vehicleProperties.Add("MaxCapcity", getMaxCapacity());

                            break;
                    }

                    break;
                }

                newCustomer(out o_CustomerName, out o_CustomerPhone);
                myGarage.InsertNewVehicleIntoGarage(i_vehicleProperties, o_CustomerName, o_CustomerPhone);
                string msg = string.Format("\n The {0} was added succesfully to our system", eVehicleType);
                Console.WriteLine(msg);
                Console.WriteLine();
            }

            if (!isVehicleNewInGarage)
            {
                string vehicleAlreadyInGarage = string.Format(
        @"Error according to our system the vehicle
registered with the given licence number is already in our garage in repair");
                Console.WriteLine(vehicleAlreadyInGarage);
            }
        }

        private static float getMaxCapacity()
        {
            bool isValid = false;
            float o_MaxCapacity = 0;
            while (!isValid)
            {
                Console.WriteLine("Please insert the max capacity:");
                string inputFromUser = Console.ReadLine();
                isValid = float.TryParse(inputFromUser, out o_MaxCapacity);
                if (isValid && o_MaxCapacity > 0)
                {
                    break;
                }

                Console.WriteLine("Illegal input please try again:");
            }

            return o_MaxCapacity;
        }

        private static bool checkIfDangerousMaterials()
        {
            bool carryDangerousMaterials = true;
            bool isValid = false;
            string msg = string.Format(
@"Does the truck carry dangerous materials:
1. Yes
2. No");
            while (!isValid)
            {
                Console.WriteLine(msg);
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    carryDangerousMaterials = true;
                    isValid = true;
                    break;
                }
                else if (userInput == "2")
                {
                    carryDangerousMaterials = false;
                    isValid = true;
                    break;
                }

                Console.WriteLine("Inalid input you can press either 1 or 2");
            }

            return carryDangerousMaterials;
        }

        private static void showMotorLicenceTypeMenu()
        {
            string mainMenu = string.Format(
@"Please press the number corresponding to your licence type:
1. AA
2. BB
3. B1
4. A");
            Console.WriteLine(mainMenu);
        }

        private static eLicenseType retrieveLicenceType()
        {
            string inputFromUser;
            eLicenseType eLicenseType;

            showMotorLicenceTypeMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eLicenseType = (eLicenseType)int.Parse(inputFromUser);
            }
            catch
            {
                Console.WriteLine("Illegal input please try again");
                return retrieveLicenceType();
            }

            return eLicenseType;
        }

        private static int getEngineVolume()
        {
            bool isValid = false;
            int o_EngineVolume = 0;
            while (!isValid)
            {
                Console.WriteLine("Please insert the engine's volume:");
                string inputFromUser = Console.ReadLine();
                isValid = int.TryParse(inputFromUser, out o_EngineVolume);
                if (isValid && o_EngineVolume > 0)
                {
                    break;
                }

                Console.WriteLine("Illegal input please try again:");
            }

            return o_EngineVolume;
        }

        private static void showNumOfDoorsMenu()
        {
            string mainMenu = string.Format(
@"Please enter number of doors:
2. Two doors
3. Three doors
4. Four doors
5. Five doors");
            Console.WriteLine(mainMenu);
        }

        private static eNumOfDoors retrieveNumberOfDoors()
        {
            string inputFromUser;
            eNumOfDoors eNumOfDoors;

            showNumOfDoorsMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eNumOfDoors = (eNumOfDoors)int.Parse(inputFromUser);
            }
            catch
            {
                Console.WriteLine("Illegal input please try again");
                return retrieveNumberOfDoors();
            }

            return eNumOfDoors;
        }

        private static void showColorMenu()
        {
            string mainMenu = string.Format(
@"Please enter color:
1. Black
2. White
3. Silver
4. Red");
            Console.WriteLine(mainMenu);
        }

        private static eColor retrieveColor()
        {
            string inputFromUser;
            eColor eColor;

            showColorMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eColor = (eColor)int.Parse(inputFromUser);
            }
            catch
            {
                Console.WriteLine("Illegal input please try again");
                return retrieveColor();
            }

            return eColor;
        }

        private static string getLicenceNumberFromUser()
        {
            bool isValidInput = false;
            string inputNumberFromUser = string.Empty;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter Israeli license number or press E to return to main menu");
                inputNumberFromUser = Console.ReadLine();
                if (inputNumberFromUser == "e" || inputNumberFromUser == "E")
                {
                    break;
                }
                isValidInput = int.TryParse(inputNumberFromUser, out int o_VehicleLicenceNumber);
                isValidInput = isValidInput && inputNumberFromUser.Length == 7;
                if (isValidInput)
                {
                    break;
                }

                Console.WriteLine("Invalid phone number please try again");
            }

            return inputNumberFromUser;
        }

        private void printLicenseOfVehiclesInTheGarage(List<string> o_ListOfLicenseNumbersToDisplay)
        {
            int numberOfLicenseNumbersToDisplay = o_ListOfLicenseNumbersToDisplay.Count;

            if (numberOfLicenseNumbersToDisplay == 0)
            {
                Console.WriteLine("No license numbers to display.");
                displayLicenseOfVehiclesInTheGarage();
            }
            else
            {
                Console.WriteLine("List of licenses (according to your filter option):");
                foreach (string licencePlate in o_ListOfLicenseNumbersToDisplay)
                {
                    Console.WriteLine(licencePlate);
                }
            }
        } 

            private void displayLicenseOfVehiclesInTheGarage()
        {
            List<string> o_ListOfLicenseNumbersToDisplay = new List<string>();
            eVehicleStatus eVehicleStatus;
            
            while (true)
            {
                eVehicleStatus = retrieveUserFilterSelection();
                switch (eVehicleStatus)
                {
                    case eVehicleStatus.None:
                    case eVehicleStatus.InRepair:
                    case eVehicleStatus.Repaired:
                        o_ListOfLicenseNumbersToDisplay = myGarage.GetLicenseNumberByVehicleStatus(eVehicleStatus);
                        break;
                }

                break;
            }
            printLicenseOfVehiclesInTheGarage(o_ListOfLicenseNumbersToDisplay);
            
        }

        private static void showFilterMenu()
        {
            string mainMenu = string.Format(
@"Please display the licence numbers by the following filter:
1. Display All - No Filter
2. Vehicles in Repair
3. Repaired Vehicles
4. Payment Done");
            Console.WriteLine(mainMenu);
        }

        private static eVehicleStatus retrieveUserFilterSelection()
        {
            string inputFromUser;
            eVehicleStatus eVehicleStatus;

            showFilterMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eVehicleStatus = (eVehicleStatus)int.Parse(inputFromUser);
            }
            catch 
            {
                Console.WriteLine("Illegal input");
                return retrieveUserFilterSelection();
            }

            return eVehicleStatus;
        }

        private static eVehicleStatus retrieveUserVehicleStatus()
        {
            string inputFromUser;
            eVehicleStatus eVehicleStatus;

            showVehicleUpdateStatusMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eVehicleStatus = (eVehicleStatus)(int.Parse(inputFromUser) + 1);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return retrieveUserFilterSelection();
            }

            return eVehicleStatus;
        }

        private void updateVehicleStatusInGarage()
        {
            eVehicleStatus i_eVehicleStatus;
            string o_LicenceNumber = getLicenceNumberFromUser();

            if(o_LicenceNumber == "E" || o_LicenceNumber == "e")
            {
                return;
            }
            
            while (true)
            {
                i_eVehicleStatus = retrieveUserVehicleStatus();
                switch (i_eVehicleStatus)
                {
                    case eVehicleStatus.InRepair:
                    case eVehicleStatus.Repaired:
                    case eVehicleStatus.Paid:
                        try
                        {
                            myGarage.UpdateVehicleStatus(o_LicenceNumber, i_eVehicleStatus);
                        }
                        catch (VehicleNotInGarageException ex)
                        {
                            Console.WriteLine(ex.Message);
                            updateVehicleStatusInGarage();
                        }

                        break;
                }

                break;
            }
        }

        private static void showVehicleUpdateStatusMenu()
        {
            string statusMenu = string.Format(
@"Please choose which status would you like to set for the current vehicle:
1. In Repair
2. Repaired Vehicle
3. Payment Done");
            Console.WriteLine(statusMenu);
        }

        private void inflateTiresToMaximum()
        {
            string o_LicenceNumber = getLicenceNumberFromUser();

            if(o_LicenceNumber == "E" || o_LicenceNumber == "e")
            {
                return;
            }

            try
            {
                myGarage.InflameTires(o_LicenceNumber);
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                inflateTiresToMaximum();
            }
        }

        private void refuelVehicle()
        {
            string vehicleNum = getLicenceNumberFromUser();
            float amountToRefuel;
            bool o_ExitProgram = false;
            eFuelType eFuelType;

            while (true)
            {
                eFuelType = retrieveFuelType();
                switch (eFuelType)
                {
                    case eFuelType.Soler:
                    case eFuelType.Octan95:
                    case eFuelType.Octan96:
                    case eFuelType.Octan98:
                        amountToRefuel = getAmountToRefuelOrCharge(out o_ExitProgram);
                        if (o_ExitProgram)
                        {
                            break;
                        }

                        try
                        {
                            myGarage.RefuelVehicle(amountToRefuel, eFuelType, vehicleNum);
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (VehicleNotInGarageException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (WrongFuelTypeExeption ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                return;
            }
        }

        private static float getAmountToRefuelOrCharge(out bool o_ExitProgram)
        {
            bool isValidInput = true;
            float o_VehicleLicenceNumber = 0;
            string inputNumberFromUser = string.Empty;
            o_ExitProgram = false;

            while (!isValidInput)
            { 
                Console.WriteLine("Please enter amount to fill or press E to return to main menu");
                inputNumberFromUser = Console.ReadLine();
                if (inputNumberFromUser == "E" || inputNumberFromUser == "e")
                {
                    o_ExitProgram = true;
                    break;
                }
                isValidInput = float.TryParse(inputNumberFromUser, out o_VehicleLicenceNumber);
                isValidInput = isValidInput && o_VehicleLicenceNumber > 0;
                if (isValidInput)
                {
                    break;
                }

                Console.WriteLine("Invalid input please try again:");
            }
            return o_VehicleLicenceNumber;
        }

        private static void showFuelTypeMenu()
        {
            string fuelMenu = string.Format(
@"Please choose what type of fuel do you want fill:
1. Soler
2. Octan95
3. Octan96
4. Octan98");
            Console.WriteLine(fuelMenu);
        }

        private static eFuelType retrieveFuelType()
        {
            string inputFromUser;
             eFuelType eFuelType;

            showFuelTypeMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eFuelType = (eFuelType)int.Parse(inputFromUser);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return retrieveFuelType();
            }

            return eFuelType;
        }

        private void chargeVehicle()
        {
            string vehicleNum = getLicenceNumberFromUser();
            float amountToCharge;
            bool o_ExitProgram = false;
            
            amountToCharge = getAmountToRefuelOrCharge(out o_ExitProgram);
            if (o_ExitProgram)
            {
                return;
            }

            try
            {
                myGarage.ChargeVehicle(amountToCharge, vehicleNum);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
            }      
        }

        private void displayVehicleInformation()
        {
            string vehicleInformation = string.Empty;
            string o_licenceNumber = getLicenceNumberFromUser();

            if(o_licenceNumber == "E" || o_licenceNumber == "e")
            {
                return;
            }

            try
            {
                vehicleInformation = myGarage.GetVehicleInformation(o_licenceNumber);
            }
            catch (VehicleNotInGarageException ex)
            {
                Console.WriteLine(ex.Message);
                displayVehicleInformation();
            }
            Console.WriteLine(vehicleInformation);
        }
    }
}
