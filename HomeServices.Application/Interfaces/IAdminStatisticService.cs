using HomeServices.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IAdminStatisticService
    {
        Task<AdminStatisticDto> GetAdminStatisticsAsync();
    }

}
