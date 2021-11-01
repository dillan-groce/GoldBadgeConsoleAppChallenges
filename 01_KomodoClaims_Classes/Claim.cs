using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoClaims_Classes
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int claimid, string claimtype, string description, double claimammount, DateTime dateofaccident, DateTime dateofclaim, bool isvalid)
        {
            ClaimID = claimid;
            ClaimType = claimtype;
            Description = description;
            ClaimAmmount = claimammount;
            DateOfAccident = dateofaccident;
            DateOfClaim = dateofclaim;
            IsValid = isvalid;
        }
        public override string ToString() => $"{ClaimID} \t{ClaimType} \t{Description} \t{ClaimAmmount} \t\t{DateOfAccident} \t\t{DateOfClaim} \t{IsValid}";
    }
}
