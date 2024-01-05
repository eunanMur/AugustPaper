using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustPaper
{
    internal class RandomMemberGenerator
    {
        public List<Member> GenerateRandomMembers()
        {
            var members = new List<Member>();
            var rand = new Random();

            // Predefined names for randomization (excluding Liam Torsney, who will be added separately)
            string[] firstNames = { "Sophie", "Grace", "Harry", "Luke", "Michael", "Sean", "Ava", "Jack", "Olivia", "William", "Emily", "James", "Emma", "Benjamin", "Charlotte", "Henry", "Abigail", "Alexander", "Ella", "Thomas", "Mia", "Daniel", "Lucy", "Samuel", "Lily", "Joseph", "Sophia" };
            string[] lastNames = { "O'Neill", "Walsh", "Lynch", "Nolan", "Daly", "Brennan", "Dunne", "McCarthy", "Ryan", "Kennedy", "Doyle", "Murphy", "Kelly", "O'Sullivan", "Byrne", "O'Connor", "Collins", "Wilson", "Harrison", "Anderson", "Campbell", "Parker", "Carter", "Robinson", "Wright", "King", "Wood", "Evans" };

            int numberOfMembers = 28;
            for (int i = 0; i < numberOfMembers; i++)
            {
                string firstName = firstNames[rand.Next(firstNames.Length)];
                string lastName = lastNames[rand.Next(lastNames.Length)];

                members.Add(new Member(firstName, lastName, GenerateRandomDateOfBirth(rand)));
            }

            return members;
        }

        private DateTime GenerateRandomDateOfBirth(Random rand) // Q5 helper method
        {
            var start = new DateTime(2005, 1, 1);
            var end = new DateTime(2011, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}
