using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Claims_Based_Security
{
    //http://dotnetcodr.com/2013/02/11/introduction-to-claims-based-security-in-net4-5-with-c-part-1/
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            CheckCompatibilityWithIprincipalAndIIdentity();
            CheckNewClaimsUsage();
            Console.ReadLine();
        }

        private static void Setup()
        {
            /* A claim in the world of authentication and authorisation can be defined as a statement about an entity, typically a user*/

            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Gabriel")
                , new Claim(ClaimTypes.Country, "Ireland")
                , new Claim(ClaimTypes.Gender, "M")
                , new Claim(ClaimTypes.Surname, "Gonzalez")
                , new Claim(ClaimTypes.Email, "hello@me.com")
                , new Claim(ClaimTypes.Role, "IT")
            };

            //There is a new implementation of the well-known IIdentity interface called ClaimsIdentity. This implementation holds an IEnumerable of Claim objects. This means that this type of identity is described by an arbitrary number of statements.
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, "My e-commerce website");

            Console.WriteLine(claimsIdentity.IsAuthenticated);

            //Using our identity object we can also create an IPrincipal:
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            //As ClaimsPrincipal implements IPrincipal we can assign the ClaimsPrincipal to the current Thread as the current principal:
            Thread.CurrentPrincipal = principal;
        }

        private static void CheckCompatibilityWithIprincipalAndIIdentity()
        {
            IPrincipal currentPrincipal = Thread.CurrentPrincipal;
            Console.WriteLine(currentPrincipal.Identity.Name);
            Console.WriteLine(currentPrincipal.IsInRole("IT"));
        }
        private static void CheckNewClaimsUsage()
        {
            ClaimsPrincipal currentClaimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            Claim nameClaim = currentClaimsPrincipal.FindFirst(ClaimTypes.Name);
            Console.WriteLine(nameClaim.Value);
        }
    }
}
