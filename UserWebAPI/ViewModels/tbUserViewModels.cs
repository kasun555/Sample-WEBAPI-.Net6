using System.ComponentModel.DataAnnotations;

namespace UserWebAPI.ViewModels
{
    public class tbUserViewModels
    {


        public int IUserId { get; set; }
        [Required]
        [StringLength(128)]
        public string StrFirstName { get; set; }

        [StringLength(128)]
        public string? StrLastName { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string StrEmail { get; set; }

        [Required]
        protected internal DateTime DtDateOfBirth { get; set; }

        public int IAge {
            get
            {

                if (DtDateOfBirth == null)
                {
                    return 0;
                }
                else
                {

                    if (DateTime.Now.Year < DtDateOfBirth.Year)
                    {
                        return (DateTime.Now.Year - DtDateOfBirth.Year) - 1; 

                    }
                    else
                    {
                        return (DateTime.Now.Year - DtDateOfBirth.Year);

                    ;
                    }
                }
            }

        }

    }
}
