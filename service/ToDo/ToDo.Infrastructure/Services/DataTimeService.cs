using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Services;

namespace ToDo.Infrastructure.Services;

public class DataTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}