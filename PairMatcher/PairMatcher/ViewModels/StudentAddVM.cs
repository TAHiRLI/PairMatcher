using System.ComponentModel.DataAnnotations;

namespace PairMatcher.ViewModels
{
    public class StudentAddVM
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public bool SameGenderMatch { get; set; }
    }
}
