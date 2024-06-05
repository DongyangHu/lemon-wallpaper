using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    internal class ImgDownloadTools
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> HttpRequest(ImgSourceConfig.Source source, Func<JObject, ImgSourceConfig.Source, string> imgUrlfunc)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(source.BaseUrl + source.SubUrl);
                httpResponseMessage.EnsureSuccessStatusCode();
                string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject jObject = JsonConvert.DeserializeObject<JObject>(jsonContent);
                if (jObject != null)
                {
                    return imgUrlfunc.Invoke(jObject, source);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }

        public static async Task<bool> DownloadFile(string url, string filePath, string fileName)
        {
            try
            {
                if (!ExistsOrCreateDirectory(filePath))
                {
                    return false;
                }
                string realPath = filePath + Path.DirectorySeparatorChar + fileName;
                if (File.Exists(realPath))
                {
                    return true;
                }

                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                byte[] fileBytes = await responseMessage.Content.ReadAsByteArrayAsync();
                using (FileStream fs = new FileStream(realPath, FileMode.Create, FileAccess.Write))
                {
                    await fs.WriteAsync(fileBytes, 0, fileBytes.Length);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return false;
        }

        /// <summary>
        /// 判断文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true:存在/创建成功；false:不存在&创建失败</returns>
        public static bool ExistsOrCreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(@path))
                {
                    Directory.CreateDirectory(@path);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
