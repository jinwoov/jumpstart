﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models
{
    public class UserJob
    {
        public int UserID { get; set; }
        public int JobID { get; set; }

        public Job Job { get; set; }
        public User User { get; set; }
    }
}
