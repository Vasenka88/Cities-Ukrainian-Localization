using ICities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ColossalFramework.Plugins;
using System.Reflection;

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !
// ! This mod is based on Chinese Tradisional localization https://github.com/ccpz/cities-skylines-Mod_Lang_CHT
// ! Thank you a lot, Taiwanese creators!
// !
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

namespace Mod_Lang_UA
{
    public class Mod_Lang_UA : IUserMod
    {
        private string locale_name = "ua";

        //
        //the following OS detect code is referring http://stackoverflow.com/questions/10138040/how-to-detect-properly-windows-linux-mac-operating-systems
        //
        public enum Platform
        {
            Windows,
            Linux,
            Mac
        }

        public static Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }

        //------------------------------------------------------------
        // Create destination path to copy the locale file to
        //------------------------------------------------------------
        private string getDestinationPath()
        {
            String dst_path = "";
#if (DEBUG)
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("OS Type: {0}", RunningPlatform().ToString()));
#endif
            switch (RunningPlatform())
            {
                case Platform.Windows:
                    dst_path = "Files\\Locale\\" + locale_name + ".locale";
                    break;
                case Platform.Mac:
                    dst_path = "Cities.app/Contents/Resources/Files/Locale/" + locale_name + ".locale";
                    break;
                case Platform.Linux:
                    dst_path = "Files/Locale/" + locale_name + ".locale";
                    break;
            }

#if (DEBUG)
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("Destination {0}", dst_path));
#endif

            return dst_path;
        }

        //------------------------------------------------------------
        // Force to reload the locale manager
        //------------------------------------------------------------
        private void resetLocaleManager(String loc_name)
        {
            // Reload Locale Manager
            ColossalFramework.Globalization.LocaleManager.ForceReload();

            string[] locales = ColossalFramework.Globalization.LocaleManager.instance.supportedLocaleIDs;
            for (int i = 0; i < locales.Length; i++)
            {
#if (DEBUG)
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("Locale index: {0}, ID: {1}", i, locales[i]));
#endif
                if (locales[i].Equals(loc_name))
                {
#if (DEBUG)
                    DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("Find locale {0} at index: {1}", loc_name, i));
#endif
                    ColossalFramework.Globalization.LocaleManager.instance.LoadLocaleByIndex(i);

                    //thanks to: https://github.com/Mesoptier/SkylineToolkit/commit/d33f0bae67662df25bdf8ee2170d95a6999c3721
                    ColossalFramework.SavedString lang_setting = new ColossalFramework.SavedString("localeID", "gameSettings");
#if (DEBUG)
                    DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("Current Language Setting: {0}", lang_setting.value));
#endif
                    lang_setting.value = locale_name;
                    ColossalFramework.GameSettings.SaveAll();
                    break;
                }
            }
        }

        //------------------------------------------------------------
        // Locale file size
        //------------------------------------------------------------
        private long LocaleFileSize()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream src = asm.GetManifestResourceStream(asm.GetName().Name + "." + locale_name + ".locale");
            long l = src.Length;
            src.Close();
            return l;
        }

        //------------------------------------------------------------
        // Copy the locale file
        //------------------------------------------------------------
        private void copyLocaleFile(String dst_path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream src = asm.GetManifestResourceStream(asm.GetName().Name + "." + locale_name + ".locale");
#if (DEBUG)
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("File size: {0}", st.Length));
#endif

            FileStream dst = File.Open(dst_path, FileMode.Create);

            byte[] buffer = new byte[8 * 1024];
            int len = 0;
            while ((len = src.Read(buffer, 0, buffer.Length)) > 0)
            {
                dst.Write(buffer, 0, len);
            }
            dst.Close();
            src.Close();

#if (DEBUG)
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format("File write to: {0}", Path.GetFullPath(dst.Name)));
#endif
        }

        //============================================================
        // Main
        //============================================================
        private void CopyLocaleAndReloadLocaleManager()
        {
            try
            {
                Boolean first_install = true;

                String dst_path = getDestinationPath();

                if ((dst_path.Length > 0) && File.Exists(dst_path))
                {
                    FileInfo f = new FileInfo(dst_path);
                    if (f.Length == LocaleFileSize())
                    {
#if (DEBUG)
                        DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Locale file is found, user has already used this mod before.");
#endif
                        first_install = false;
                    }
                }
                if (first_install == true)
                {
                    DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Locale file for locale " + locale_name +
                        " does not exist or has wrong file size. Installing file to " + dst_path);
                    copyLocaleFile(dst_path);
                    DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Done, game language will now be switched to " + locale_name);
                    resetLocaleManager(locale_name);
                }
            }
            catch (Exception e)
            {
                //				#if (DEBUG)
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, e.ToString());
                //				#endif
            }
        }

        //============================================================
        // Modding API
        //============================================================
        public void OnEnabled()
        {
            CopyLocaleAndReloadLocaleManager();
        }

        public string Name
        {
            get
            {
                /* We want to make the name of the mod appear in the right language too if the target language is selected. And while
				   we are at it, let's add some more languages to be polite to speakers of other language who are trying our mod
				   for whatever reason. */
                ColossalFramework.SavedString lang_setting = new ColossalFramework.SavedString("localeID", "gameSettings");
                switch (lang_setting.value)
                {
                    case "de":
                        return "Ukrainische Ubersetzung-mod";
                    case "es":
                        return "Mod traduccién Ucraniano";
                    case "fr":
                        return "Mod traduction Ukrainienne";
                    case "it":
                        return "Mod traduzione Ucraina";
                    //case "nl":
                        //return "Oekraïense vertaling-mod";
                    case "ua":
                        return "Українізатор";
					case "ru":
                        return "Українізатор";
                    case "pl":
                        return "Ukraińska lokalizacja";
                    default:
                        return "Українізатор";
                }
            }
        }

        public string Description
        {
            get
            {
                /* We want to make the description of the mod appear in the right language too if the target language is selected. And while
				   we are at it, let's add some more languages to be polite to speakers of other language who are trying our mod
				   for whatever reason. */
                ColossalFramework.SavedString lang_setting = new ColossalFramework.SavedString("localeID", "gameSettings");
                switch (lang_setting.value)
                {
                    case "de":
                        return "Ukrainische Lokalisierung von Cities: Skylines, Übersetzung: Kemza, mod: Vasenka88";
                    case "es":
                        return "Localización ucraniana de Cities: Skylines, traducción: Kemza, mod: Vasenka88";
                    case "fr":
                        return "Localisation ukrainienne des Cities: Skylines, traduction: Kemza, mod: Vasenka88";
                    case "it":
                        return "Localizzazione ucraina delle Cities: Skylines, traduzione: Kemza, mod: Vasenka88";
                    //case "nl":
                        //return "Oekraïense vertaling van Cities: Skylines, door Vasenka88.";
                    case "ua":
                        return "Українська локалізація Cities: Skylines, переклад: Kemza, мод: Vasenka88.";
					case "ru":
						return "Українська локалізація Cities: Skylines, переклад: Kemza, мод: Vasenka88.";
                    case "pl":
                        return "Ukraińska lokalizacja dla Cities: Skylines, tłumaczenie: Kemza, mod: Vasenka88.";
                    default:
                        return "Українська локалізація Cities: Skylines, переклад: Kemza, мод: Vasenka88.";
                }
            }
        }
    }
}