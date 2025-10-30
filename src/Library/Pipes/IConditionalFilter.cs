namespace CompAndDel.Pipes
{
    public interface IConditionalFilter : IFilter
    {
        bool Result { get; }
    }


}