﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;

public class OrderAction
{
    public int Id { get; set; }
    public int OrderId { get; set; }    

    // public OrderStatus Status { get; set; }
    public OrderActionType ActionType { get; set; }
}
