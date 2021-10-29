namespace useless
{
    public interface IMenuOperation
    {
        string Description { get; }
        void Execute();
    }
}