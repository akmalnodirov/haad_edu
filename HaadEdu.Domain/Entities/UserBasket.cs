using System.Net.Sockets;

namespace HaadEdu.Domain.Entities;

public class UserBasket
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public IList<long>? CourseId { get; set; }
}
