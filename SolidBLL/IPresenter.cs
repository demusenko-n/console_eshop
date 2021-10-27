namespace SolidBLL
{
    public interface IPresenter
    {
        string Read();
        void Write(string text);
        void Clear();
        void Pause();
    }
}