using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDashboardApp.Models
{
    public enum MajorIndexType
    {
        DowJones,
        Nasdaq,
        Apple
    }
    public class MajorIndex
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double change { get; set; }
    }
}
