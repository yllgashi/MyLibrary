﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class ClientOffer
    {
        public Offer Offer { get; set; }
        public DateTime AgreementDate { get; set; }
    }
}