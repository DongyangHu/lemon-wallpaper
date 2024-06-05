namespace lemon_wallpaper.service
{
    internal interface IWallpaperService
    {
        string DownloadImg(ImgSourceConfig.Source source);
        void InitData();
    }
}
