﻿using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Elle Sowulewski
    // Dated Created: 1/26/2020
    // Last Modified: 
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":

                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":

                        UserProgrammingisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":

                        DisplayDance(myFinch);
                        break;

                    case "c":

                        DisplayMixingItUp(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show");
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show > Dance                       *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its dancing talent!");

            finchRobot.setMotors(255, -255);
            finchRobot.wait(500);
            finchRobot.setMotors(-255, 255);
            finchRobot.wait(500);
            finchRobot.setMotors(255, -255);
            finchRobot.wait(500);
            finchRobot.setMotors(-255, 255);
            finchRobot.wait(500);
            finchRobot.setMotors(255, -255);
            finchRobot.wait(1500);

            finchRobot.setMotors(0, 0);

            DisplayContinuePrompt();
            DisplayMenuPrompt("Talent Show");
        }

        /// <summary>
        /// *****************************************************************
        /// *                 Talent Show > Mixing it Up                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch robot will now show off its talent!");

            finchRobot.setMotors(255, -255);
            finchRobot.noteOn(565);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setMotors(-255, 255);
            finchRobot.noteOn(700);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setMotors(255, -255);
            finchRobot.noteOn(565);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(500);
            finchRobot.setMotors(-255, 255);
            finchRobot.noteOn(700);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setMotors(255, -255);
            finchRobot.noteOn(565);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(1500);
            finchRobot.setLED(0, 0, 0);

            finchRobot.setMotors(0, 0);


            DisplayContinuePrompt();
            DisplayMenuPrompt("Talent Show");
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                      Data Recorder                            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {

            Console.CursorVisible = false;

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();

                        break;

                    case "b":

                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();

                        break;

                    case "c":

                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":

                        DataRecorderDisplayDataTable(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);

        }

        /// <summary>
        /// *****************************************************************
        /// *             Data Recorder > Data Point Number                 *
        /// *****************************************************************
        /// </summary>
        ///

        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            string userResponse;

            DisplayScreenHeader("Number of Data Points");
            Console.WriteLine("\tPlease enter the number of data points:");

            userResponse = Console.ReadLine();
            int.TryParse(userResponse, out numberOfDataPoints);

            DisplayContinuePrompt();

            return numberOfDataPoints;

        }

        /// <summary>
        /// *****************************************************************
        /// *            Data Recorder > Data Point Frequency               *
        /// *****************************************************************
        /// </summary>
        ///

        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;

            DisplayScreenHeader("Data Point Frequency");
            Console.WriteLine("\tPlease enter the data point frequency [seconds].");

            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;


        }

        /// <summary>
        /// *****************************************************************
        /// *                   Data Recorder > Get Data                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of data points = {numberOfDataPoints}");
            Console.WriteLine($"\tFrequency of data points = {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tApplication is ready to record temperature data. Press any key to continue.");
            Console.ReadKey();

            for (int index = 0; index < numberOfDataPoints; index++)
            {

                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading: {index + 1} : {temperatures[index]:n2}");
                int waitInSeconds = (int)(dataPointFrequency * 1000); 
                finchRobot.wait(waitInSeconds);

            }

            DisplayContinuePrompt();

            return temperatures;
        }


        /// <summary>
        /// *****************************************************************
        /// *                  Data Recorder > Show Data                    *
        /// *****************************************************************
        /// </summary>
        ///

        static void DataRecorderDisplayDataTable(double[] temperatures)
        {

            DisplayScreenHeader("Show Data");

            Console.WriteLine(

                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)

                );

            Console.WriteLine(

                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)

                );

            for (int index = 0; index < temperatures.Length; index++)
            {

                Console.WriteLine(

                    (index +1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)

                    );

            }

            DisplayContinuePrompt();

        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                         Light Alarm                           *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {

            Console.CursorVisible = false;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Min/Max Threshold");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":


                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":


                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":

                        minMaxThresholdValue = LightAlarmDisplaySetMinMaxThresholdValue(rangeType, finchRobot);
                        break;

                    case "d":

                        timeToMonitor = LightAlarmDisplaySetTimeToMonitor();
                        break;

                    case "e":

                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

            DisplayContinuePrompt();

        }


        /// <summary>
        /// *****************************************************************
        /// *            Light Alarm < Set Sensors To Monitor               *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static string LightAlarmDisplaySetSensorsToMonitor()
        {

            string sensorsToMonitor;

            DisplayScreenHeader("Set Sensors To Monitor");

            Console.Write("\tSensors to Monitor [left, right, both]");
            sensorsToMonitor = Console.ReadLine();
            Console.WriteLine($"\tSensors to Monitor set to: {sensorsToMonitor}");

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;

        }

        /// <summary>
        /// *****************************************************************
        /// *                  Light Alarm < Range Type                     *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static string LightAlarmDisplaySetRangeType()
        {

            string rangeType;

            DisplayScreenHeader("Set Range Type");

            Console.Write("\tRange Type [minimum/maximum]");
            rangeType = Console.ReadLine();
            Console.WriteLine($"\tRange Type set to: {rangeType}");

            DisplayMenuPrompt("Light Alarm");

            return rangeType;

        }

        /// <summary>
        /// *****************************************************************
        /// *                Light Alarm < Threshold Value                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {

            int minMaxThresholdValue;

            DisplayScreenHeader("Set Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tLeft right sensor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();

            Console.WriteLine($"\tEnter the {rangeType} light sensor value:");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);

            Console.WriteLine($"\tThe {rangeType} is set to {minMaxThresholdValue}.");

            DisplayMenuPrompt("Light Alarm Menu");

            return minMaxThresholdValue;

        }

        /// <summary>
        /// *****************************************************************
        /// *                Light Alarm < Time To Monitor                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static int LightAlarmDisplaySetTimeToMonitor()
        {

            int timeToMonitor;

            DisplayScreenHeader("Set Time to Monitor");

            Console.WriteLine("\tPlease enter the time to monitor in seconds.");
            int.TryParse(Console.ReadLine(), out timeToMonitor);

            DisplayMenuPrompt("Light Alarm Menu");

            return timeToMonitor;

        }

        /// <summary>
        /// *****************************************************************
        /// *                   Light Alarm < Set Alarm                     *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static void LightAlarmSetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {

            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange type: {rangeType}");
            Console.WriteLine($"\tMin/Max threshold value: {minMaxThresholdValue}");
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to set alarm and start monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {

                switch(sensorsToMonitor)
                {

                    case "left":

                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":

                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":

                        currentLightSensorValue = (finchRobot.getRightLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;

                }

                switch(rangeType)
                {

                    case "minimum":

                        if (currentLightSensorValue < minMaxThresholdValue)
                        {

                            thresholdExceeded = true;

                        }

                        break;

                    case "maximum":

                        if (currentLightSensorValue > minMaxThresholdValue)
                        {

                            thresholdExceeded = true;

                        }

                        break;
                }

                secondsElapsed ++;

            }

            if (thresholdExceeded)
            {

                Console.WriteLine($"\tThe {rangeType} threshold value was exceeded by the current light value: {currentLightSensorValue} ");

            }
            else 
            {

                Console.WriteLine($"\tThe {rangeType} threshold value was not exceeded by the current light value: {currentLightSensorValue} ");

            }

            DisplayMenuPrompt("Alarm Light Menu");

        }

        #endregion

        #region USER PROGRAMMING

        /// <summary>
        /// *****************************************************************
        /// *                      User Programming                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void UserProgrammingisplayMenuScreen(Finch finchRobot)
        {

            Console.CursorVisible = false;

            DisplayScreenHeader("User Programming");

            Console.WriteLine("\tThis module is still under development.");

            DisplayContinuePrompt();

        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>

        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;

        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
