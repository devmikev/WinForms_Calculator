namespace WindowsFormsApp1
{
    public interface IOperator
    {
        string Name { get; }
        string Display { get; }
        int Apply(int x, int y);
    }
}