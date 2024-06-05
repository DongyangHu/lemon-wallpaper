using System;
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
    public static class TimeTools
    {
        private readonly static string ONLY_NUM = "yyyyMMdd";
        private readonly static string GENERAL = "yyyy-MM-dd HH:mm:ss";


        public static string TimeNumber()
        {
            return DateTime.Now.ToString(ONLY_NUM);
        }

        public static string TimeGeneral()
        {
            return DateTime.Now.ToString(GENERAL);
        }

        public static DateTime TimeGeneral0()
        {
            return DateTime.Today;
        }

        public static DateTime TimeDate(string time)
        {
            return DateTime.Parse(time);
        }

        public static DateTime TimeBeforeDays(int days)
        {
            DateTime dateTime = DateTime.Now.AddDays(-days);
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
