using RestaurantG5.Controller;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantG5.Model.Common
{
    class Param
    {
        public const int TABLES_BY_SQUARE = 6;
        public const int WAITER_BY_SQUARE = 1;
        public const int RANKCHIEF_NUMBER = 2;
        public static int MAP_NUMBER = Int32.Parse(ParamController.GetValueOrDefault("MAP_NUMBER", "40"));
        public static int SPEED = Int32.Parse(ParamController.GetValueOrDefault("SPEED", "1"));

        public static string KICHEN_SERVER_LOCAL_IP = ParamController.GetValueOrDefault("KICHEN_SERVER_LOCAL_IP", "127.0.0.1");
        public static int KITCHEN_SERVER_COMMAND_PORT = Int32.Parse(ParamController.GetValueOrDefault("KITCHEN_SERVER_COMMAND_PORT", "9897"));
        public static bool KITCHEN_SERVER_STARTED = false;

        public static string SALLE_CLIENT_LOCAL_IP = ParamController.GetValueOrDefault("SALLE_CLIENT_LOCAL_IP", "127.0.0.1");
        public static int SALLE_CLIENT_COMMAND_PORT = Int32.Parse(ParamController.GetValueOrDefault("SALLE_CLIENT_COMMAND_PORT", "9897"));
        public static bool SALLE_CLIENT_STARTED = false;

        public static int SALLE_NUMBER = 1;

        public static string LOG_PATH = Directory.GetCurrentDirectory() + "\\Log.txt";

        private static Dictionary<string, int> options;

        public static Dictionary<string, int> Options { get => options; set => options = value; }
    }
}
