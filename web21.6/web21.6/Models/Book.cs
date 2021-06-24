using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web21._6.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        private int v1;
        private string v2;
        private string v3;

        public Book()
        {

        }

        public Book(int v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Book(int id, string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề sách không được vượt quá 250 kí tự")]
        [Display(Name = "Tiêu đề")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string ImageCover
        {
            get { return image_cover; }
            set { image_cover = value; }
        }
        
    }
}
