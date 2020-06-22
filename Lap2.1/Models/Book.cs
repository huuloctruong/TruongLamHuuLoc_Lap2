using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lap2._1.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        private string edit;
        private string delete;
        private int v1;
        private string v2;
        private string v3;
        private string v4;

        public Book()
        {

        }

        public Book(int v1, string v2, string v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public Book(int id,string title,string author,string image_cover,string edit,string delete)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
            this.edit = edit;
            this.delete = delete;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required(ErrorMessage ="Tiêu đề không được bỏ trống")]
        [StringLength(250,ErrorMessage ="Tiêu đề không vượt quá 250 ký tự")]
        [Display(Name ="Title")]
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
        public string Edit
        {
            get { return edit; }
            set { edit = value; }
        }
        public string Delete
        {
            get { return delete; }
            set { delete = value; }
        }
     

    }
}