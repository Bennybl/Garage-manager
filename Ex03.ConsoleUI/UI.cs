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


        public static void ExecutePrograms()
        {
            eUserChoice eUserChoice = eUserChoice.InsertNewVehicle;
            myGarage = new GarageManager();
            while (true)
            {
                eUserChoice = retrieveUserProgramSelection();
                switch (eUserChoice)
                {
                    case eUserChoice.InsertNewVehicle:
                        insertNewVehicle();
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
            if(eUserChoice == eUserChoice.Abort)
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

        private static void insertNewVehicle()
        {
            Console.WriteLine("Please insert the vehicle license number");
            string vehicleLicenseNumber = Console.ReadLine();

            bool v = myGarage.InsertVehicle(32);
            /// check input


        }

        private static void displayLicenseOfVehiclesInTheGarage()
        {
            List<string> listOfLicenseNumbersToDisplay = new List<string>();
            eVehicleStatus eVehicleStatus;
            int numberOfLicenseNumbersToDisplay;
            
            while (true)
            {
                eVehicleStatus = retrieveUserFilterSelection();
                switch (eVehicleStatus)
                {
                    case eVehicleStatus.None :
                    case eVehicleStatus.InRepair:
                    case eVehicleStatus.Repaired :
                        listOfLicenseNumbersToDisplay = s_MyGarage.GetLicenseNumberByVehicleStatus(eVehicleStatus);
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
                foreach(string licencePlate in listOfLicenseNumbersToDisplay)
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

            showMainMenu();
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

    }
}
