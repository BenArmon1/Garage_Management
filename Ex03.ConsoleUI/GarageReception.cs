using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageReception
    {
        private Garage m_OurGarage = new Garage();

        public Garage OurGarage
        {
            get { return m_OurGarage; }
        }

        public void Run()
        {
            bool thereAreMoreVehiclesComingInForRepair = true;
            while (thereAreMoreVehiclesComingInForRepair)
            {
                Console.WriteLine("Hi, you have arrived at Bar & Ben Garage Ltd.");
                Console.WriteLine("Which Vehicle Do you have?");
                bool validVehicle = false;
                bool theVhicleCanHandleInOurGarage = true;
                string vehicleType = " ";

                while (!validVehicle)
                {
                    vehicleType = Console.ReadLine();
                    validVehicle = Factory.CheckValidtionOfTheNewVehicle(vehicleType);
                    if (!validVehicle)
                    {
                        theVhicleCanHandleInOurGarage = false;
                        Console.WriteLine("Sorry we can't handle your vehicle");
                        break;
                    }
                }

                Dictionary<string, string> featuresOfTheVehicle = new Dictionary<string, string>();
                List<string> featuresOfTheVehicleMessages = null;
                Vehicle vehicleOfCustomer = Factory.MakingNewVehicleForCustomer(vehicleType, out featuresOfTheVehicleMessages);

                if (theVhicleCanHandleInOurGarage)
                {
                    Console.WriteLine("Please bring me the following details");
                }

                for (int i = 0; i < featuresOfTheVehicleMessages.Count && theVhicleCanHandleInOurGarage; i++)
                {
                    Console.WriteLine(featuresOfTheVehicleMessages[i] + ":");
                    string featureFromUser = "";
                    bool checkDetailsValidtion = false;

                    while (!checkDetailsValidtion)
                    {
                        try
                        {
                            featureFromUser = Console.ReadLine();
                            bool check = vehicleOfCustomer.CheckValidtionForCustomerDetails(featureFromUser, featuresOfTheVehicleMessages[i]);

                            if (check)
                            {
                                checkDetailsValidtion = true;
                            }

                            featuresOfTheVehicle.Add(featuresOfTheVehicleMessages[i], featureFromUser);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == "Sorry we can't handle your car")
                            {
                                theVhicleCanHandleInOurGarage = false;
                                Console.WriteLine(ex);
                                break;
                            }

                            Console.WriteLine(ex);
                            checkDetailsValidtion = false;
                        }
                    }
                }

                if (theVhicleCanHandleInOurGarage)
                {
                    vehicleOfCustomer.SetFeaturesForTheVhicle(featuresOfTheVehicle);
                    OurGarage.AddANewVechileToTheGarage(vehicleOfCustomer);
                    Console.Clear();
                    bool youHaveMoreRequestsForCareOfYourVehile = true;

                    while (youHaveMoreRequestsForCareOfYourVehile)
                    {
                        Console.WriteLine("What repair would you like to do in your vehicle");
                        Console.WriteLine(string.Format(@"The option is:
1.See the list of vehicle license numbers in the garage, with the option to filter by their state.
2.See the list of vehicle license numbers in the garage - all of them.
3.Change the state of vehicle in the garage.
4.To inflate the wheels of a vehicle to the maximum.
5.Refuel with a fuel-powered vehicle.
6.Charge an electric vehicle.
7.View complete vehicle data.
Enter the number of the repair that you want to do"));
                        int numberOfRepair = int.Parse(Console.ReadLine());

                        Console.Clear();
                        try
                        {
                            RepairThatTheCustomerWantToDo(numberOfRepair, vehicleOfCustomer);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("Do you want to do another vehilce repair? answer yes or no");
                        if (Console.ReadLine() == "no")
                        {
                            youHaveMoreRequestsForCareOfYourVehile = false;
                            Console.WriteLine("There are more vehicles who have come to the garage - yes or not");
                            string answerIfThereMorePeople = Console.ReadLine();
                            if (answerIfThereMorePeople == "yes")
                            {
                                Console.Clear();
                            }
                            else
                            {
                                thereAreMoreVehiclesComingInForRepair = false;
                            }

                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There are more vehicles who have come to the garage - yes or not");
                    string answerIfThereMorePeople = Console.ReadLine();

                    if (answerIfThereMorePeople == "yes")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        thereAreMoreVehiclesComingInForRepair = false;
                    }
                }
            }
        }

        public void RepairThatTheCustomerWantToDo(int i_NumberOfTheRepair, Vehicle i_CustomerVehicle)
       {
            if (i_NumberOfTheRepair == 1)
            {
                Console.WriteLine(string.Format(@"Which state do you want to see?
The option are inrepair, fixed, payed"));
                string state = Console.ReadLine();
                List <string> vehicleByState = OurGarage.VehiclesInTheGarageByStateOfTheVehicleInTheGarage(state);
                Console.WriteLine(string.Format("The list of vehicle license numbers in the garage by state - {0} are:", state));
                Console.WriteLine(OurGarage.ListToString(vehicleByState));
            }
            else if (i_NumberOfTheRepair == 2)
            {
                Console.WriteLine("The list of vehicle license numbers in the garage");
                Console.WriteLine(OurGarage.ListToString(OurGarage.AllVehiclesInTheGarage()));
            }
            else if (i_NumberOfTheRepair == 3)
            {
                Console.WriteLine(string.Format(@"What is the new state that you want?
The option are inrepair, fixed, payed"));
                string state = Console.ReadLine();
                Console.WriteLine("Your id");
                string cutomerId = Console.ReadLine();
                OurGarage.ChangeVehicleState(cutomerId, state);
            }
            else if (i_NumberOfTheRepair == 4)
            {
                OurGarage.ToInflateTheWheelsOfAVehicleToTheMax(i_CustomerVehicle.LicensePlate);
            }
            else if (i_NumberOfTheRepair == 5)
            {
                    Console.WriteLine("What fuel do you want to use? - the option is soler, octan95, octan96, octan98");
                    string fuelType = Console.ReadLine();
                    Console.WriteLine("How much would you like to refuel your vehicle");
                    float fuelAmount = float.Parse(Console.ReadLine());
                    try
                    {
                        OurGarage.ToFillGas(i_CustomerVehicle.LicensePlate, fuelType, fuelAmount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    } 
            }
            else if (i_NumberOfTheRepair == 6)
            {
                    Console.WriteLine("How long do you want to charge your vehicle - in mintues");
                    float batteryAmount = float.Parse(Console.ReadLine());
                    try
                    {
                        OurGarage.ToFillBatary(i_CustomerVehicle.LicensePlate, batteryAmount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
            }
            else if (i_NumberOfTheRepair == 7)
            {
                Console.WriteLine(OurGarage.ToStringAllDataByLicensePlate(i_CustomerVehicle.LicensePlate));
            }
        }
    }
}
