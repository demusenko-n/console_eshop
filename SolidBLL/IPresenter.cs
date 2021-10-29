namespace SolidBLL
{
    public interface IPresenter
    {
        string Read();
        void WriteLine(string text);
        void Clear();
        void Pause();
    }
}