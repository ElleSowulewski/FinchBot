using System;
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

    public enum Command
    {
    
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNLEFT,
        TURNRIGHT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE

    }

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
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            themeColors = ReadThemeData();
            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
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
                Console.WriteLine("\tg) Customize Theme");
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

                        AlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":

                        UserProgrammingisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "g":
                        DisplaySetTheme();
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
        /// *                         Alarm                                 *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void AlarmDisplayMenuScreen(Finch finchRobot)
        {

            Console.CursorVisible = false;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            bool monitorTemperature = false;
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Monitor Temperature");
                Console.WriteLine("\tc) Set Range Type");
                Console.WriteLine("\td) Set Min/Max Threshold");
                Console.WriteLine("\te) Set Time to Monitor");
                Console.WriteLine("\tf) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":


                        sensorsToMonitor = AlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":


                        monitorTemperature = AlarmDisplayMonitorTemp();
                        break;

                    case "c":

                        rangeType = AlarmDisplaySetRangeType();
                        break;

                    case "d":

                        minMaxThresholdValue = AlarmDisplaySetMinMaxThresholdValue(rangeType, monitorTemperature, finchRobot);
                        break;

                    case "e":

                        timeToMonitor = AlarmDisplaySetTimeToMonitor();
                        break;

                    case "f":


                        AlarmSetAlarm(finchRobot, sensorsToMonitor, monitorTemperature, rangeType, minMaxThresholdValue, timeToMonitor);
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
        /// *                Alarm < Set Sensors To Monitor                 *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static string AlarmDisplaySetSensorsToMonitor()
        {

            string sensorsToMonitor;

            DisplayScreenHeader("Set Sensors To Monitor");

            Console.Write("\tLight sensors to Monitor [left, right, both]");
            sensorsToMonitor = Console.ReadLine();
            Console.WriteLine($"\tSensors to Monitor set to: {sensorsToMonitor}");

            DisplayMenuPrompt("Alarm Menu");

            return sensorsToMonitor;

        }

        /// <summary>
        /// *****************************************************************
        /// *                    Alarm < Monitor Temp                       *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static bool AlarmDisplayMonitorTemp()
        {

            bool monitorTemp;
            string input;

            DisplayScreenHeader("Monitor Temp");

            Console.Write("\tShould temperature be monitored as well? [yes/no]");
            input = Console.ReadLine();
            
            if (input == "yes")
            {
                monitorTemp = true;
            }
            else
            {

                monitorTemp = false;

            }

            Console.WriteLine($"\tMonitor Temperature set to: {monitorTemp}");

            DisplayMenuPrompt("Alarm Menu");

            return monitorTemp;

        }

        /// <summary>
        /// *****************************************************************
        /// *                     Alarm < Range Type                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static string AlarmDisplaySetRangeType()
        {

            string rangeType;

            DisplayScreenHeader("Set Range Type");

            Console.Write("\tRange Type [minimum/maximum]");
            rangeType = Console.ReadLine();
            Console.WriteLine($"\tRange Type set to: {rangeType}");

            DisplayMenuPrompt("Alarm Menu");

            return rangeType;

        }

        /// <summary>
        /// *****************************************************************
        /// *                   Alarm < Threshold Value                     *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static int AlarmDisplaySetMinMaxThresholdValue(string rangeType, bool monitorTemp, Finch finchRobot)
        {

            int minMaxThresholdValue;

            DisplayScreenHeader("Set Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tLeft right sensor ambient value: {finchRobot.getRightLightSensor()}");

            if(monitorTemp == true)
            {
    
                Console.WriteLine($"\tTemperature ambient value: {finchRobot.getTemperature()}");

            }
            
            Console.WriteLine();

            Console.WriteLine($"\tEnter the {rangeType} sensor value:");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);

            Console.WriteLine($"\tThe {rangeType} is set to {minMaxThresholdValue}.");

            DisplayMenuPrompt("Alarm Menu");

            return minMaxThresholdValue;

        }

        /// <summary>
        /// *****************************************************************
        /// *                    Alarm < Time To Monitor                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static int AlarmDisplaySetTimeToMonitor()
        {

            int timeToMonitor;

            DisplayScreenHeader("Set Time to Monitor");

            Console.WriteLine("\tPlease enter the time to monitor.");
            int.TryParse(Console.ReadLine(), out timeToMonitor);

            DisplayMenuPrompt("Alarm Menu");

            return timeToMonitor;

        }

        /// <summary>
        /// *****************************************************************
        /// *                      Alarm < Set Alarm                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static void AlarmSetAlarm(Finch finchRobot, string sensorsToMonitor, bool monitorTemperature, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {

            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;
            double currentTemperatureValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tMonitor Temperature: {monitorTemperature}");
            Console.WriteLine($"\tRange type: {rangeType}");
            Console.WriteLine($"\tMin/Max threshold value: {minMaxThresholdValue}");
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to set alarm and start monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) || (!thresholdExceeded))
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

                switch(monitorTemperature)
                {

                    case true:

                        currentTemperatureValue = finchRobot.getTemperature();
                        break;

                }

                switch(rangeType)
                {

                    case "minimum":

                        if (currentLightSensorValue < minMaxThresholdValue && currentTemperatureValue < minMaxThresholdValue)
                        {

                            thresholdExceeded = true;

                        }

                        break;

                    case "maximum":

                        if (currentLightSensorValue > minMaxThresholdValue && currentTemperatureValue > minMaxThresholdValue)
                        {

                            thresholdExceeded = true;

                        }

                        break;
                }

                secondsElapsed ++;

            }

            if (thresholdExceeded)
            {

                Console.WriteLine($"\tThe {rangeType} threshold value was exceeded by the current sensor values: ");
                Console.WriteLine($"\t{currentLightSensorValue}");
                
                if (monitorTemperature == true)
                {

                    Console.WriteLine($"\t{currentTemperatureValue}");

                }

            }
            else 
            {

                Console.WriteLine($"\tThe {rangeType} threshold value was not exceeded");

            }

            DisplayMenuPrompt("Alarm Menu");

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

            bool quitMenu = false;
            string menuChoice;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

             do
             {
                DisplayScreenHeader("User Programming");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Excecute Commands");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":

                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":

                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":

                        UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
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
        /// *            User Programming < Command Parameters              *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
        
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            int valid = 0;

            while (valid == 0)
            { 
                Console.WriteLine("\tEnter Motor Speed [1 - 255]:");
                commandParameters.motorSpeed = int.Parse(Console.ReadLine());
                if ((commandParameters.motorSpeed >= 1) && (commandParameters.motorSpeed <= 255))
                {
                    valid++;
                }
                else
                {
                    Console.WriteLine("\t Please try again. Enter a valid value between 1 and 255...");
                }
            }
            valid = 0;

            while (valid == 0)
            {
                Console.WriteLine("\tEnter LED Brightness [1 - 255]:");
                commandParameters.ledBrightness = int.Parse(Console.ReadLine());
                if ((commandParameters.ledBrightness >= 1) && (commandParameters.ledBrightness <= 255))
                {
                    valid++;
                }
                else
                {
                    Console.WriteLine("\t Please try again. Enter a valid value between 1 and 255...");
                }
            }
            valid = 0;

            while (valid == 0)
            {
                Console.WriteLine("\tEnter wait in seconds:");
                commandParameters.waitSeconds = int.Parse(Console.ReadLine());
                if ((commandParameters.waitSeconds >= 1) && (commandParameters.waitSeconds <= 10))
                {
                    valid++;
                }
                else
                {
                    Console.WriteLine("\t Please try again. Enter a valid value between 1 and 10...");
                }
            }
            valid = 0;

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait Command Duration: {commandParameters.waitSeconds}");

            DisplayMenuPrompt("User Programming");
            return commandParameters;

        }

        /// <summary>
        /// *****************************************************************
        /// *            User Programming < Get Finch Commands              *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {

            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            int commandCount = 1;

            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.WriteLine("\t-");

            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {

                Console.WriteLine($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.WriteLine("-\n\t-");
                commandCount++;

            }

            Console.WriteLine();

            while (command != Command.DONE)
            {

                Console.WriteLine("\tEnterCommand:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {

                    commands.Add(command);

                }
                else
                {

                    Console.WriteLine("\t**********************************************");
                    Console.WriteLine("\t* Please enter a command from the list above *");
                    Console.WriteLine("\t**********************************************");

                }
            }

        }


        /// <summary>
        /// *****************************************************************
        /// *             User Programming < Display Commands               *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {

            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {

                Console.WriteLine($"\t{command}");

            }

            DisplayMenuPrompt("User Programming");
        }

        
        /// <summary>
        /// *****************************************************************
        /// *             User Programming < Excecute Commands              *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void UserProgrammingDisplayExecuteFinchCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {

            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliseconds = (int)(commandParameters.waitSeconds * 1000);

            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("\tThe Finchbot is ready to excecute the list of commands...");
            DisplayContinuePrompt();

            foreach(Command command in commands)
            {

                switch(command)
                {

                    case Command.NONE:

                        break;

                    case Command.MOVEFORWARD:

                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:

                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:

                        finchRobot.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:

                        finchRobot.wait(waitMilliseconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:

                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:

                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:

                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:

                        finchRobot.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:

                        commandFeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}";
                        break;

                    case Command.DONE:

                        commandFeedback = Command.DONE.ToString();
                        break;

                    default:

                        break;

                }

                Console.WriteLine($"\t{commandFeedback}");

            }

            DisplayMenuPrompt("User Programming");

        }

        #endregion

        #region SET THEME

        /// <summary>
        /// *****************************************************************
        /// *                     Display Set Theme                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 

        static void DisplaySetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeSet = false;

            themeColors = ReadThemeData();
            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            Console.Clear();
            DisplayScreenHeader("Set Color Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the theme? [ yes / no ]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    themeColors.foregroundColor = GetColorsFromUser("foreground");
                    themeColors.backgroundColor = GetColorsFromUser("background");

                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Color Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tWould you like to keep this theme? [ yes / no ]");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeSet = true;
                        WriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);
                    }

                } while (!themeSet);
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                      Get Theme Colors                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// 


        static ConsoleColor GetColorsFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine($"\t '{validConsoleColor}' is not a valid color value. Please try again...");
                }
                else
                {
                    validConsoleColor = true;
                }

            } while (!validConsoleColor);

            return consoleColor;
        }

        /// <summary>
        /// *****************************************************************
        /// *                       Read Theme Data                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeData()
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            themeColors = File.ReadAllLines(dataPath);

            Enum.TryParse(themeColors[0], true, out foregroundColor);
            Enum.TryParse(themeColors[1], true, out backgroundColor);

            return (foregroundColor, backgroundColor);
        }

        /// <summary>
        /// *****************************************************************
        /// *                      Write Theme Data                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        ///

        static void WriteThemeData(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";

            File.WriteAllText(dataPath, foreground.ToString() + "\n");
            File.AppendAllText(dataPath, background.ToString());
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
