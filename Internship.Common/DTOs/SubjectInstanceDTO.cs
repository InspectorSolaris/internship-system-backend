﻿using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Internship.Common.Dtos
{
    public class SubjectInstanceDto : EntityDto
    {
        public int Year { get; set; }

        public ICollection<Guid> Users { get; set; }
    }
}
