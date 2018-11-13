namespace WindowsFormsApp1
{
    public interface IOperator
    {
        string Name { get; }
        string Display { get; }
        decimal Apply(decimal x, decimal y);
    }
}