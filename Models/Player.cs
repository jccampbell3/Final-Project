using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models;

public class Player {
    public int PlayerId { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    [Display(Name = "Username")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
    [Display(Name = "Title")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Strength Level must be between 1 and 100.")]
    [Display(Name = "Strength Level")]
    public int StrengthLevel { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Agility Level must be between 1 and 100.")]
    [Display(Name = "Agility Level")]
    public int AgilityLevel { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Intelligence Level must be between 1 and 100.")]
    [Display(Name = "Intelligence Level")]
    public int IntelligenceLevel { get; set; }

    [StringLength(200, ErrorMessage = "Achievements cannot exceed 200 characters.")]
    [Display(Name = "Achievements")]
    public string Achievements { get; set; } = string.Empty;

    public ICollection<HighScore> HighScores { get; set; } = new List<HighScore>();
}