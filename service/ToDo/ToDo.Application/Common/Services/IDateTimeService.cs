﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Common.Services;

public interface IDateTimeService
{
    public DateTime UtcNow { get; }
}
