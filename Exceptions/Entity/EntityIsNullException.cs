namespace Exceptions.Entity;

public class EntityIsNullException : Exception
{
    private static string _message = "Entity: Data not found!";
    public EntityIsNullException() : base(_message) { }
}
