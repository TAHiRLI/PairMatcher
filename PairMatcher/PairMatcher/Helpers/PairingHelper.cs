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

                if(i+1 < students.Count)
                {
                students[i].PairStudentId = students[i + 1].PairStudentId;
                students[i].PairStudent = students[i + 1];
                students[i + 1].PairStudent = students[i];
                students[i + 1].PairStudentId = students[i].PairStudentId;

                }
            }


        }
    }
}
