namespace Reserverly.Domain.Exceptions;

public class ForbidenException(string RequestType) : Exception($"You are not authorized to perform this operation: {RequestType}")
{

}
