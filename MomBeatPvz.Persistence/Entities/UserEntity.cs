﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
