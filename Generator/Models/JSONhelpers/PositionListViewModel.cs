﻿using System;

namespace Generator.Models.JSONhelpers
{
    public class PositionListViewModel
    {
        public int ObjectId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public TimeSpan time { get; set; }
    }
}