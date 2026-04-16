namespace Entities.DataTransferObjects;

public record UpdateItemDto(Guid id, string? Name, string? Description, float? Price);
