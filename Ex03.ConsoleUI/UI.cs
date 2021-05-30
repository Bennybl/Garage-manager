﻿using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ex03.ConsoleUI
{
    class UI
    {
        private GarageManager myGarage;
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


        public void ExecutePrograms()
        {
            myGarage = new GarageManager();
            executeUserProgramSelection();
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
            string inputFromUser;
            eUserChoice eUserChoice;

            showMainMenu();
            inputFromUser = Console.ReadLine();
            try
            {
                eUserChoice = (eUserChoice)int.Parse(inputFromUser);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return retrieveUserProgramSelection();
            }

            return eUserChoice;
        }

        private void executeUserProgramSelection()
        {
            eUserChoice eUserChoice = eUserChoice.InsertNewVehicle;
            while (true)
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

                        break;
                    case eUserChoice.DisplayVehicleInformation:

                        break;
                }
                break;
            }
            if (eUserChoice == eUserChoice.Abort)
            {
                return;
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
            catch (Exception ex)
            {
                ex.ToString();
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
            catch (Exception ex)
            {
                ex.ToString();
                return retrieveVehicelType(eEngineBased);
            }
            if (eEngineBased == eEngineBased.Electricty && vehicleType != 1 && vehicleType != 2)
            {
                Console.WriteLine("wrong input please try again:");
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
                if (!Char.IsLetter(c))
                {
                    isValidInput = false;
                    break;
                }
            }

            return isValidInput;
        }

        private static string getCustomerNameFromUser()
        {
            bool isValidFirstName = true;
            bool isValidLastName = true;
            bool isValidInput = false;
            string inputStringFromUser = string.Empty;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter your full name (first and last name\n");
                inputStringFromUser = Console.ReadLine();
                string[] firstAndLastName = inputStringFromUser.Split(',');
                if (firstAndLastName.Length == 2)
                {
                    isValidFirstName = isOnlyLetters(firstAndLastName[0]);
                    isValidLastName = isOnlyLetters(firstAndLastName[1]);
                    isValidInput = isValidFirstName && isValidLastName; 
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
            string VehicleNumberFromUser = getLicenceNumberFromUser();
            string o_CustomerName = string.Empty;
            string o_CustomerPhone = string.Empty;

            bool isVehicleNewInGarage = myGarage.InsertVehicle(VehicleNumberFromUser);
            eEngineBased eEngineBased;
            Dictionary<string, object> i_vehicleProperties = new Dictionary<string, object>();
            //benny shouldchange the method name to isInGarage
            if (!isVehicleNewInGarage)
            {
                string vehicleAlreadyInGarage = string.Format(
@"Error according to our system the vehicle
registered with the given licence number is already in our garage in repair");
                Console.WriteLine(vehicleAlreadyInGarage);
            }

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
            newCustomer(out o_CustomerName, out o_CustomerPhone);
            i_vehicleProperties.Add("EngineBased", eEngineBased);
            i_vehicleProperties.Add("VehicleType", retrieveVehicelType(eEngineBased));
            i_vehicleProperties.Add("ModelName", getVehicleModelFromUser());
            i_vehicleProperties.Add("LicenceNumber", VehicleNumberFromUser);

            myGarage.InsertNewVehicleIntoGarage(i_vehicleProperties, o_CustomerName, o_CustomerPhone);

        }

        private static string getLicenceNumberFromUser()
        {
            bool isValidInput = true;

            while (true)
            {
                if (!isValidInput)
                {
                    Console.WriteLine("The input you entered is invalid. Please try again.\n");
                }

                Console.WriteLine("Please enter Israeli license number");
                string inputNumberFromUser = Console.ReadLine();
                isValidInput = int.TryParse(inputNumberFromUser, out int o_VehicleLicenceNumber);
                if (isValidInput && inputNumberFromUser.Length == 7)
                {
                    return inputNumberFromUser;
                }

                isValidInput = false;
            }
        }

        private void displayLicenseOfVehiclesInTheGarage()
        {
            List<string> listOfLicenseNumbersToDisplay = new List<string>();
            eVehicleStatus eVehicleStatus;
            int numberOfLicenseNumbersToDisplay;

            while (true)
            {
                eVehicleStatus = retrieveUserFilterSelection();
                switch (eVehicleStatus)
                {
                    case eVehicleStatus.None:
                    case eVehicleStatus.InRepair:
                    case eVehicleStatus.Repaired:
                        listOfLicenseNumbersToDisplay = myGarage.GetLicenseNumberByVehicleStatus(eVehicleStatus);
                        break;
                }
                break;
            }
            numberOfLicenseNumbersToDisplay = listOfLicenseNumbersToDisplay.Count;
            if (numberOfLicenseNumbersToDisplay == 0)
            {
                Console.WriteLine("No license numbers to display.");
            }
            else
            {
                Console.WriteLine("List of licenses (according to your filter option):");
                foreach (string licencePlate in listOfLicenseNumbersToDisplay)
                {
                    Console.WriteLine(licencePlate);
                }
            }
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
            catch (Exception ex)
            {
                ex.ToString();
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
            eVehicleStatus eVehicleStatus;
            getVehicleNumberFromUser();
            while (true)
            {
                eVehicleStatus = retrieveUserVehicleStatus();
                switch (eVehicleStatus)
                {
                    case eVehicleStatus.InRepair:
                    case eVehicleStatus.Repaired:
                        myGarage.UpdateVehicleStatus();
                        // update vehicle status
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

        private static void inflateTiresToMaximum(int o_LicenceNumberOfVehicleToInflate)
        {
            getVehicleNumberFromUser();
            // what should be here?

        }

        private static void RefuelVehicle()
        {
            int vehicleNum = getVehicleNumberFromUser();
            // how to check if in system?
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
                        getAmountOfFuelToFill();
                        // to call to Benny's method
                        break;
                }
                break;
            }


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
    }
}
