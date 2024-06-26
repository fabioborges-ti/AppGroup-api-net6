﻿namespace AppGroup.Rental.Domain.Dtos.Http;

public abstract class ResponseBasePagedDto
{
    public int Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public double TotalPages { get; set; }
}
