using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HH.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Display(Name= "Nơi tổ chức dự án")]
        [Required(ErrorMessage ="Nơi tổ chức dự án không được để trống")]
        public string Address { get; set; }
        [Display(Name = "Ngày tổ chức")]
        [Required(ErrorMessage = "Ngày tổ chức dự án không được để trống")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DateofEvent { get; set; }
        [Display(Name = "Thông tin dự án")]
        [Required(ErrorMessage = "Thông tin dự án không được để trống")]
        public string Information { get; set; }
        [Display(Name = "Nội dung chi tiết")]
        [Required(ErrorMessage = "Nội dung dự án không được để trống")]
        public string Content { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        public string ImgPath { get; set; }

        public virtual ICollection<Contributor> Contributors { get; set; }
    }
}