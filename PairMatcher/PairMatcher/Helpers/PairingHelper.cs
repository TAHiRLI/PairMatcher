using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace PairMatcher.Helpers
{
    public class PairingHelper
    {
        public static void PairStudents(List<Student> students)
        {
            Random random = new Random();


            // Grouping students depending on their choise to shuffle among them

            List<Student> OnlyGirls = students.Where(x => x.SameGenderMatch && !x.Gender).ToList();
            List<Student> OnlyBoys = students.Where(x => x.SameGenderMatch && x.Gender).ToList();
            List<Student> Remainings = students.Where(x => !x.SameGenderMatch).ToList();

            List<Student>[] studentGroups = new List<Student>[] { OnlyBoys, OnlyGirls, Remainings };




            for (int x = 0; x < studentGroups.Length; x++)
            {
                // shuffling the students list with Fisher-Yates Shuffle algorithm

                var numOfStudents = studentGroups[x].Count % 2 == 0 ? studentGroups[x].Count : studentGroups[x].Count - 1;

                for (int i = numOfStudents - 1; i > 0; i--)
                {
                    int j = random.Next(i);
                    (studentGroups[x][i], studentGroups[x][j]) = (studentGroups[x][j], studentGroups[x][i]);
                }


                // pairing the students 

                for (int i = 0; i < numOfStudents; i += 2)
                {

                    if (i + 1 < numOfStudents)
                    {
                        studentGroups[x][i].PairStudentId = studentGroups[x][i + 1].Id;
                        studentGroups[x][i].PairStudent = studentGroups[x][i + 1];
                        studentGroups[x][i + 1].PairStudent = studentGroups[x][i];
                        studentGroups[x][i + 1].PairStudentId = studentGroups[x][i].Id;

                    }
                } 



            }

            students = OnlyBoys.Concat(OnlyGirls).Concat(Remainings).ToList();

        }
    }
}
