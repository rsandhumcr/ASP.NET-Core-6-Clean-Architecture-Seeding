﻿using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Orders.GetOrdersForMonth;

public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthVm>
{
    public DateTime Date { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}