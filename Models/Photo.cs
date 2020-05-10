﻿using System;

namespace DatingAPI.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DatedAdded { get; set; }

        public bool IsMain { get; set; }
        
    }
}