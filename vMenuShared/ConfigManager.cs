﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace vMenuShared
{
    public static class ConfigManager
    {

        public enum Setting
        {
            vmenu_use_permissions,
            vmenu_menu_staff_only,

            vmenu_menu_toggle_key,
            vmenu_noclip_toggle_key,

            vmenu_keep_spawned_vehicles_persistent,

            vmenu_enable_weather_sync,
            vmenu_enable_dynamic_weather,

            vmenu_dynamic_weather_timer,
            vmenu_default_weather,
            vmenu_allow_random_blackout,

            vmenu_enable_time_sync,
            vmenu_default_time_hour,
            vmenu_default_time_min,
            vmenu_ingame_minute_duration,

            vmenu_auto_ban_cheaters,
            vmenu_log_ban_actions,
            vmenu_log_kick_actions,
            vmenu_outdated_version_notify_players,

            vmenu_use_els_compatibility_mode
        }


        //private static Dictionary<string, Dictionary<string, string>> Config = new Dictionary<string, Dictionary<string, string>>();

        //private static bool initialized = false;

        //public static bool InitializeConfig()
        //{
        //    if (!initialized)
        //    {
        //        string file = LoadResourceFile("vMenu", "config/config.ini");
        //        if (!string.IsNullOrEmpty(file))
        //        {
        //            initialized = true;
        //            return ParseConfig(file);
        //        }
        //        SendErrorMessage("File could not be found or it's empty.");
        //    }
        //    initialized = true;
        //    return false;
        //}

        //private static bool ParseConfig(string config)
        //{
        //    if (!string.IsNullOrEmpty(config))
        //    {
        //        config = config.Replace("\r", "");
        //        string lastKey = "";
        //        foreach (string line in config.Split('\n'))
        //        {
        //            if (!(string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line)) && !line.StartsWith(";") && !line.StartsWith("#"))
        //            {
        //                if (line.StartsWith("[") && line.EndsWith("]"))
        //                {
        //                    lastKey = line.Replace("[", "").Replace("]", "");
        //                    Config[lastKey] = new Dictionary<string, string>();
        //                }
        //                else
        //                {
        //                    if (!string.IsNullOrEmpty(lastKey) && Config[lastKey] != null)
        //                    {
        //                        string key = line.Split('=')[0];
        //                        string value = line.Split('=')[1];

        //                        if (key != null && value != null)
        //                        {
        //                            Config[lastKey].Add(key, value);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return true;
        //    }

        //    SendErrorMessage("The config was empty or the file does not exist.");
        //    return false;
        //}


        //private static void SendErrorMessage(string details)
        //{
        //    if (IsDuplicityVersion())
        //    {
        //        Debug.Write("^1[vMenu] [ERROR] ^0" + details + "^0\n");
        //    }
        //    else
        //    {
        //        Debug.Write("[vMenu] " + details + "\n");
        //    }

        //}


        public static bool GetSettingsBool(Setting setting)
        {
            return GetConvar(setting.ToString(), "false") == "true";
        }

        public static int GetSettingsInt(Setting setting)
        {
            int convarInt = GetConvarInt(setting.ToString(), -1);
            if (convarInt == -1)
            {
                if (int.TryParse(GetConvar(setting.ToString(), "-1"), out int convarIntAlt))
                {
                    return convarIntAlt;
                }
            }
            return convarInt;
        }

        public static float GetSettingsFloat(Setting setting)
        {
            if (float.TryParse(GetConvar(setting.ToString(), "-1.0"), out float result))
            {
                return result;
            }
            return -1f;
        }

        public static string GetSettingsString(Setting setting)
        {
            return GetConvar(setting.ToString(), "");
        }
    }
}
