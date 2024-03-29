﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; private set; }
        public void Delete() => IsDeleted = true;
        public void RevokeDelete() => IsDeleted = false;

    }
}
