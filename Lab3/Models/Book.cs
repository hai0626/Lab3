namespace Lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Tên sách không được bỏ trống")]
        [StringLength(20,ErrorMessage ="Tên sách không được quá 20 ký tự")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên sách không được quá 100 ký tự")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được bỏ trống")]
        [StringLength(30, ErrorMessage = "Tên sách không được quá 30 ký tự")]
        public string TacGia { get; set; }

        [Required(ErrorMessage = "Nội dung không được bỏ trống")]
        [StringLength(255)]
        public string NoiDung { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được bỏ trống")]
        [StringLength(50)]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Giá tiền không được bỏ trống")]
        [Range(1000,1000000,ErrorMessage ="Giá tiền nằm trong khoảng 1000 - 1000000")]
        public int? GiaTien { get; set; }
    }
}
