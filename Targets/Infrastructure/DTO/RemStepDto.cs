﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.DTO
{
    public class RemStepDTO
    {
        public Guid ProjectId { get; set; }
        public Guid StepId { get; set; }
       
    }
}
