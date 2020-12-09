using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ClaimsRepo
    {
        private Queue<Claim> _claims = new Queue<Claim>();

        //Create
        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        //Read
        public Queue<Claim> ViewClaimList()
        {
            return _claims;
        }

        //Delete
        public bool DeleteClaim(int id)
        {
            Claim claim = GetClaimByID(id);

            if(claim == null)
            {
                return false;
            }

            int initialCount = _claims.Count;
            _claims.Dequeue();

            if (initialCount > _claims.Count)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        //Helper Methods
        public Claim GetClaimByID(int id)
        {
            foreach(Claim claim in _claims)
            {
                if(claim.ClaimID == id)
                {
                    return claim;
                }
            }

            return null;
        }
    }
}
