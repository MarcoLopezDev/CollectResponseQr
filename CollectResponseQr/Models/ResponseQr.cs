using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectResponseQr.Models
{
    public class ResponseQr
    {
        [Key]
        public Guid PayId { get; set; }
        public string QrId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
    }
}
