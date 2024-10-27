using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20,MinimumLength =5)]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }


        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }


        [StringLength(200, MinimumLength = 5)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        

        public string Category { get; set; }

        [Required(ErrorMessage ="Language is required")]
        public string Language { get; set; }
        [Range(0, 999, ErrorMessage = "Can only be between 0 .. 999")]
        [Required(ErrorMessage = "TotalPages is required")]
        [Display(Name = "Total Pages of Book", Prompt ="456", Description="Must be numbers")]
        public int? TotalPages { get; set; }


        [Display(Name = "Choose the cover photo of your book")]
        [Required(ErrorMessage = "CoverPhoto is required")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageURL { get; set; }
        [Display(Name = "Choose the Images of your book")]
        [Required(ErrorMessage = "Images are required")]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> GalleryList { get; set; }

        [Display(Name = "Choose the PFD of your book")]
        [Required(ErrorMessage = "Upload your Book in PDF format")]
        public IFormFile BookPDF { get; set; }
        public string BookPdfURL { get; set; }


    }
}
