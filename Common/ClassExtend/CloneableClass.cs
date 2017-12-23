namespace MUnityLibrary.Common
{
    public class CloneableClass<T>
    {
        public T Clone()
        {
            return (T) MemberwiseClone();
        }
    }
}