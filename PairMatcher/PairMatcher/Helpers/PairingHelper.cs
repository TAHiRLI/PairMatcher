namespace PairMatcher.Helpers
{
    public  class PairingHelper
    {
        public static void PairStudents(List<Student> students)
        {
            Random random = new Random();


            // shuffling the students list with Fisher-Yates Shuffle algorithm
            for (int i = students.Count - 1; i > 0; i--)
            {
                int j = random.Next(i);
               (students[i], students[j]) = (students[j], students[i]);
            }

            // pairing the students 

            for (int i = 0; i < students.Count; i+=2)
            {
                students[i].PairStudent = students[i + 1];
                students[i].PairStudentId = students[i + 1].PairStudentId;

                students[i + 1].PairStudent = students[i];
                students[i + 1].PairStudentId = students[i].PairStudentId;
            }


        }
    }
}
