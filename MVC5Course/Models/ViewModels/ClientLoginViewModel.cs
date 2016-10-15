using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [DisplayName("名")]
        [Required]
        [StringLength(10, ErrorMessage = "{0} Firstname Cannot input over {1} words.")]
        public string FirstName { get; set; }
        [DisplayName("中間名")]
        [Required]
        [StringLength(10, ErrorMessage = "{0} Middlename Cannot input over {1} words.")]
        public string MiddleName { get; set; }
        [DisplayName("姓")]
        [Required]
        [StringLength(10, ErrorMessage = "{0} Lastname Cannot input over {1} words.")]
        public string LastName { get; set; }
        [DisplayName("性別")]
        [Required]
        [RegularExpression("[MF]", ErrorMessage = "{0}只能輸入M或F!")]
        public string Gender { get; set; }
    }
}