using PairMatcher.Models;
using System.ComponentModel.DataAnnotations;

namespace PairMatcher
{
    public class Student : Base
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Gender { get; set; } = true;
        public bool SameGenderMatch { get; set; } = false;

        public Student? PairStudent { get; set; }
        public int? PairStudentId { get; set; }
    }
}
