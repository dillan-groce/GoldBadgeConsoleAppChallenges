using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoClaims_Classes
{
    public class ClaimsRepo
    {
        private Queue<Claim> _repo = new Queue<Claim>();


        //Create a Claim
        public bool AddClaim(Claim claim)
        {
            int startingCount = _repo.Count;
            _repo.Enqueue(claim);

            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read

        //  Get All Claims
        public Queue<Claim> GetAllClaims()
        {
            return _repo;
        }

        //  Return next Claim but do not remove it from the Queue
        public Claim PeekClaim()
        {
            if (_repo.Peek() != null)
            {
                return _repo.Peek();
            }
            return null;
        }

        ////Update a Claim //NOT IMPLIMENTED NOT TESTED
        //public bool UpdateClaim(int claimID,Claim newClaim)
        //{
        //    Claim claim = GetClaimByID(claimID);
        //    if (claim != null)
        //    {
        //        claim.ClaimID = newClaim.ClaimID;
        //        claim.Type = newClaim.Type;
        //        claim.Description = newClaim.Description;
        //        claim.ClaimAmount = newClaim.ClaimAmount;
        //        claim.DateOfIncident = newClaim.DateOfIncident;
        //        claim.DateOfClaim = newClaim.DateOfClaim;
        //        return true;
        //    }
        //    else { return false; }
        //}

        //Delete  Top Claim from Queue
        public bool DequeueClaim()
        {
            int startingCount = _repo.Count;
            _repo.Dequeue();

            bool wasDequeued = (_repo.Count < startingCount) ? true : false;
            return wasDequeued;
        }
    }
}
