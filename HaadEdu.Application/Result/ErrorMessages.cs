using System.Net;

namespace HaadEdu.Application.Result;

public class ErrorMessages
{
    public static KeyValuePair<int, string> Internal = new((int)HttpStatusCode.InternalServerError, "internal");
    public static KeyValuePair<int, string> InvalidPermission = new((int)HttpStatusCode.BadRequest, "invalid_permission");
    public static KeyValuePair<int, string> BadRequest = new((int)HttpStatusCode.BadRequest, "badrequest");
}
