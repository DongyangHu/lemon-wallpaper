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
namespace lemon_wallpaper.service.impl
{
    public abstract class AbstractImgHistoryService : IImgHistoryService
    {
        private readonly object _lockObject = new object();

        public int CurrentImgIndex()
        {
            return LockRun(DoCurrentImgIndex);
        }

        public void Init()
        {
            LockRun(DoInit);
        }

        public int NextImgIndex()
        {
            return LockRun(DoNextImgIndex);
        }

        public int PreviousImgIndex()
        {
            return LockRun(DoPreviousImgIndex);
        }

        public int SetWallpaper(string imgPath)
        {
            return LockRun(imgPath, DoSetWallpaper);
        }

        public int SetWallpaper(int imgIndex)
        {
            return LockRun(imgIndex, DoSetWallpaper);
        }

        public void DeleteExpireImg()
        {
            LockRun(DoDeleteExpireImg);
        }

        private R LockRun<R>(Func<R> func)
        {
            lock (_lockObject)
            {
                return func();
            }
        }

        private void LockRun(Action action)
        {
            lock (_lockObject)
            {
                action();
            }
        }

        private R LockRun<I, R>(I param, Func<I, R> func)
        {
            lock (_lockObject)
            {
                return func(param);
            }
        }

        protected abstract int DoCurrentImgIndex();
        protected abstract int DoNextImgIndex();
        protected abstract int DoPreviousImgIndex();
        protected abstract void DoInit();
        protected abstract int DoSetWallpaper(string imgPath);
        protected abstract int DoSetWallpaper(int imgIndex);
        protected abstract void DoDeleteExpireImg();
    }
}
