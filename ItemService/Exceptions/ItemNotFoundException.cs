namespace Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(Guid id)
        : base($"Item with id '{id}' was not found.") { }
}
