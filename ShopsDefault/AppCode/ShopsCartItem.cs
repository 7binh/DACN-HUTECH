using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class ShopsCartItem
{
    public int ID_Product { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
    public double PriceOut { get; set; }
    public string Image { get; set; }
    public double Total
    {
        get
        {
            return Amount * PriceOut;
        }
    }
}