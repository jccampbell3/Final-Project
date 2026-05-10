using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models;

public class HighScore {
    public int HighScoreId { get; set; }

    [Required(ErrorMessage = "Player is required.")]
    [Display(Name = "Player")]
    public int PlayerId { get; set; }

    [Required(ErrorMessage = "Boss is required.")]
    [Display(Name = "Boss")]
    public int BossId { get; set; }

    [Required]
    [Range(0, 10000, ErrorMessage = "Kill Count must be between 0 and 10,000.")]
    [Display(Name = "Kill Count")]
    public int KillCount { get; set; }
    public Player Player { get; set; } = null!;
    public Boss Boss { get; set; } = null!;
}