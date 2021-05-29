using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UI
    {
        private enum eUserChoice
        {
            InsertNewVehicle = 1 ,
            DisplayListOfVehicles = 2 ,
            UpdateVehicleStatus = 3 ,
            InflateTiresToMaximum = 4 ,
            RefuelVehicle = 5 ,
            ChargeElectricVehicle = 6 ,
            DisplayVehicleInformation = 7 ,
            Abort = 8
        }

        private enum eFilterMenu
        {
            None = 1,
            InRepair = 2,
            Repaired = 3,
            Paid = 4
        }

        public static void ExecutePrograms()
        {
            eUserChoice eUserChoice = eUserChoice.InsertNewVehicle;

            while (eUserChoice != eUserChoice.Abort)
            {
                eUserChoice = retrieveUserProgramSelection();
                switch (eUserChoice)
                {
                    case eUserChoice.InsertNewVehicle:
                        initiateGame(o_ScreenSize, true);
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
    }
}
