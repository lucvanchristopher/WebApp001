using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp001.Models;

public class Image
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Path { get; set; }

    [NotMapped]
    [Display(Name = "Image")]
    public IFormFile File { get; set; }

    public int FruitId { get; set; }

    public virtual Fruit Fruit { get; set; }
}
