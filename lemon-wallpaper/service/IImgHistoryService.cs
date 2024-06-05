namespace lemon_wallpaper.service
{
    public interface IImgHistoryService
    {
        int PreviousImgIndex();
        int NextImgIndex();
        int CurrentImgIndex();
        void Init();
        int SetWallpaper(string imgPath);
        int SetWallpaper(int imgIndex);
        void DeleteExpireImg();
    }
}
