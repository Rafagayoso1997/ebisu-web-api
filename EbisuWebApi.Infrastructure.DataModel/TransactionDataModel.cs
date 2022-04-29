using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.DataModel
{
    public class TransactionDataModel
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public UserDataModel User { get; set; }
        public int UserId { get; set; }
        public CategoryDataModel Category { get; set; }
        public int CategoryId { get; set; }
    }
}
