using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models;

public class Boss {
    public int BossId { get; set; }

    [Required(ErrorMessage = "Boss name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
    [Display(Name = "Boss Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Strength Level must be between 1 and 100.")]
    [Display(Name = "Strength Level")]
    public int StrengthLevel { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Defense Level must be between 1 and 100.")]
    [Display(Name = "Defense Level")]
    public int DefenseLevel { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Speed Level must be between 1 and 100.")]
    [Display(Name = "Speed Level")]
    public int SpeedLevel { get; set; }

    [Required(ErrorMessage = "Loot items are required.")]
    [StringLength(300, ErrorMessage = "Loot Items cannot exceed 300 characters.")]
    [Display(Name = "Loot Items")]
    public string LootItems { get; set; } = string.Empty;
    public ICollection<HighScore> HighScores { get; set; } = new List<HighScore>();
}