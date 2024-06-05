///
/// Copyright 2024 DongyangHu, hudongyang123@gmail.com
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///   http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
namespace lemon_wallpaper.tools
{
    public static class SettingsTools
    {
        public static void UpdateSetting<T>(string key, T value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
        }

        public static int GetIntSetting(string key)
        {
            return (int)Properties.Settings.Default[key];
        }

        public static string GetStringSetting(string key)
        {
            return (string)Properties.Settings.Default[key];
        }

        public static bool GetBoolSetting(string key)
        {
            return (bool)Properties.Settings.Default[key];
        }
    }
}
