using System.ComponentModel.DataAnnotations;


namespace KitaplikUygulama.Models
{
    public class Category
    {

        [Key]
        public int ID { get; set; }
        [Required]
        //[MaxLength(50]
        [StringLength(50, ErrorMessage = "Name Can Not Be Longer")]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Display Order Should Be Between Only 1 and 100")]
        public int DisplayOrder { get; set; }
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;




    }
}
