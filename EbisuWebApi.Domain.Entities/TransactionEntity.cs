using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Entities
{
    public class TransactionEntity
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public UserEntity User { get; set; }
        public int UserId { get; set; }
        public CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }
    }
}
