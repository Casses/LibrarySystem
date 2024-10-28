using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        public required string CardIdentifier { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public int MaxCheckouts { get { return 5; } }

        public virtual IList<ActivityLog> CheckoutHistory { get; set; }

        public string ToString()
        {
            return $"Member: {CardIdentifier}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToString("yyyyMMdd")}";
        }
    }
}
