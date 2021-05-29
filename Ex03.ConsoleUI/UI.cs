using Ex03.GarageLogic;
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
            eUserChoice eUserChoice = eUserChoice.InsertNewVehicle;
            myGarage = new GarageManager();
            while (true)
            {
                eUserChoice = retrieveUserProgramSelection();
                switch (eUserChoice)
                {
                    case eUserChoice.InsertNewVehicle:
                        insertNewVehicle(myGarage);
                        break;
                    case eUserChoice.DisplayListOfVehicles:
                        initiateGame(o_ScreenSize, false);
                        break;
                    case eUserChoice.UpdateVehicleStatus:
                        initiateGame(o_ScreenSize, false);
                        break;
                    case eUserChoice.InflateTiresToMaximum:
                        initiateGame(o_ScreenSize, false);
                        break;
                    case eUserChoice.ChargeElectricVehicle:
                        initiateGame(o_ScreenSize, false);
                        break;
                    case eUserChoice.DisplayVehicleInformation:
                        initiateGame(o_ScreenSize, false);
                        break;
                }
                break;
            }
            if (eUserChoice == eUserChoice.Abort)
            {
                return;
            }
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

        private void insertNewVehicle()
        {
            bool isVehicleNewInGarage = myGarage.InsertVehicle(getVehicleNumberFromUser());
            if (!isVehicleNewInGarage)
            {
                string vehicleAlreadyInGarage = string.Format(
@"Error according to our system the vehicle
registered with the given licence number is already in our garage in repair");
                Console.WriteLine(vehicleAlreadyInGarage);
            }
            // GET engine type 
            // Get vehicle type
            // get model
            //to ask for tire details?
            //What parameters to ask from user


            /// check input


        }

        private static int getVehicleNumberFromUser()
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
                if (isValidInput && o_VehicleLicenceNumber == 7)
                {
                    return o_VehicleLicenceNumber;
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
