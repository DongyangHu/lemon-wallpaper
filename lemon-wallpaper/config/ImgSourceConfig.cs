using System;
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
namespace lemon_wallpaper
{
    public static class ImgSourceConfig
    {
        public static Source BING = Source.Create(0, "BING", "http://www.bing.com", "/HPImageArchive.aspx?format=js&n=1");
        public static Source BING_MODEL = Source.Create(1, "BING_MODEL", "http://cn.bing.com", "/hp/api/model");
        public static Source WALLHAVEN = Source.Create(2, "WALLHAVEN", "http://wallhaven.cc", "/api/v1/search?resolutions=1920x1080&sorting=random");


        private static readonly Dictionary<int, Source> SOURCE_INDEX_MAP;
        private static readonly Dictionary<string, Source> SOURCE_NAME_MAP;
        static ImgSourceConfig()
        {
            SOURCE_INDEX_MAP = new Dictionary<int, Source>
            {
                { BING.Index, BING },
                { BING_MODEL.Index, BING_MODEL },
                { WALLHAVEN.Index, WALLHAVEN },
            };

            SOURCE_NAME_MAP = new Dictionary<string, Source>
            {
                { BING.Name, BING },
                { BING_MODEL.Name, BING_MODEL },
                { WALLHAVEN.Name, WALLHAVEN },
            };
        }

        public static string[] Items()
        {
            return new string[] { BING.Name, BING_MODEL.Name, WALLHAVEN.Name };
        }


        /// <summary>
        /// 按照下拉选项框的index获取Source
        /// </summary>
        /// <param name="index">下拉选项框的index</param>
        /// <returns>Source</returns>
        public static Source ForIndex(int index)
        {
            return SOURCE_INDEX_MAP[index];
        }

        /// <summary>
        /// 按照英文名称获取Source
        /// </summary>
        /// <param name="name">Source英文名称</param>
        /// <returns>Source</returns>
        public static Source ForName(string name)
        {
            return SOURCE_NAME_MAP[name.ToLower()];
        }

        public class Source
        {
            private readonly int index;
            private readonly string name;
            private readonly string baseUrl;
            private readonly string subUrl;

            private Source(int index, string name, string baseUrl, string subUrl)
            {
                this.index = index;
                this.name = name ?? throw new ArgumentNullException(nameof(name));
                this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
                this.subUrl = subUrl ?? throw new ArgumentNullException(nameof(subUrl));
            }

            /// <summary>
            /// 生成Source
            /// </summary>
            /// <param name="index">下拉框选择index</param>
            /// <param name="name">英文name</param>
            /// <param name="url">源地址</param>
            /// <returns>Custom Source</returns>
            public static Source Create(int index, string name, string baseUrl, string subUrl)
            {
                return new Source(index, name, baseUrl, subUrl);
            }

            public int Index
            {
                get { return index; }
            }

            public string Name
            {
                get { return this.name; }
            }

            public string BaseUrl
            {
                get { return this.baseUrl; }
            }

            public string SubUrl
            {
                get { return this.subUrl; }
            }
        }
    }
}
