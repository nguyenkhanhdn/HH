using System;
using System.ComponentModel.DataAnnotations;

namespace HH.Models
{
    public class Contributor
    {
        public int Id { get; set; }
        [Display(Name = "Dự án")]
        [Required(ErrorMessage = "Dự án không được để trống")]
        public int ProjectId { get; set; }
        [Display(Name = "Người đóng góp")]
        [Required(ErrorMessage = "Người đóng góp không được để trống")]
        public string Fullname { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        public string Phone { get; set; }
        public string Contribution{ get; set; }
        [Display(Name = "Ngày đóng góp")]
        [Required(ErrorMessage = "Ngày đóng góp không được để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DoC { get; set; }

        public Project Project { get; set; }
    }
}