using System.Collections.Generic;

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
namespace lemon_wallpaper.config
{
    public static class ImgExpireTimeConfig
    {

        public static ExpireTime EXPIRE_TIME_7 = new ExpireTime(0, 7, "7天");
        public static ExpireTime EXPIRE_TIME_30 = new ExpireTime(1, 30, "30天");
        public static ExpireTime EXPIRE_TIME_FOREVER = new ExpireTime(2, 0, "永久保存");

        private static readonly Dictionary<int, ExpireTime> EXPIRE_TIME_INDEX_MAP = new Dictionary<int, ExpireTime>() {
            { EXPIRE_TIME_7.Index, EXPIRE_TIME_7},
            { EXPIRE_TIME_30.Index, EXPIRE_TIME_30},
            { EXPIRE_TIME_FOREVER.Index, EXPIRE_TIME_FOREVER},
        };

        /// <summary>
        /// 按照下拉选项框的index获取ExpireTime
        /// </summary>
        /// <param name="index">下拉选项框的index</param>
        /// <returns>Source</returns>
        public static ExpireTime ForIndex(int index)
        {
            return EXPIRE_TIME_INDEX_MAP[index];
        }

        public static string[] Items()
        {
            return new string[] { EXPIRE_TIME_7.Name, EXPIRE_TIME_30.Name, EXPIRE_TIME_FOREVER.Name };
        }

        public class ExpireTime
        {
            private readonly int index;
            private readonly int days;
            private readonly string name;

            public ExpireTime(int index, int days, string name)
            {
                this.index = index;
                this.days = days;
                this.name = name;
            }

            public int Index => index;
            public int Days => days;
            public string Name => name;
        }
    }
}
