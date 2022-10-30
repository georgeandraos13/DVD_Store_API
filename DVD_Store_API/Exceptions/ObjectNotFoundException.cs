namespace DVD_Store_API.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base("Object Not Found")
        {
        }
    }
}
