namespace DVD_Store_API.Exceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException() : base("Object Already Exists")
        {
        }
    }
}
