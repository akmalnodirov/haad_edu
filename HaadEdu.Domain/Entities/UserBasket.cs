﻿namespace HaadEdu.Domain.Entities;

public class UserBasket : BaseEntity
{
    public long UserId { get; set; }
    public IList<long>? CourseId { get; set; }
}