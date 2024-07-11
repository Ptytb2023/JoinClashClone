namespace Structures.Ranges.Base
{
    public interface IRange<T>
    {
        public T Max { get; set; }
        public T Min { get; set; }
    }
}