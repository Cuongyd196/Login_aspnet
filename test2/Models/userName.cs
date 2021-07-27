namespace test2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userName")]
    public partial class userName
    {
        public long ID { get; set; }

        [Display(Name = " First Name "), Required(ErrorMessage = " FirstName is required")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Display(Name = " Last Name "), Required(ErrorMessage = "LastName is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email"), Required(ErrorMessage = "Mail is required")]
        [StringLength(30)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pass is required"), StringLength(20,MinimumLength =8)]
        public string Password { get; set; }

        //[Compare(otherProperty: "Password", ErrorMessage = "New & confirm password does not match")]
        //public string ConfirmPassword { set; get; }

        [Display(Name = " Phone number "), Required(ErrorMessage = " Phone is required")]
        [StringLength(15), Phone(ErrorMessage = "Please enter a valid Phone No")]
        public string Phone { get; set; }

        [Display(Name = " Recovery Mail ")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string OldMail { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        
        [Display(Name = " Genner ")]
        public long? IDGenner { get; set; }

        public virtual Genner Genner { get; set; }
    }
}
