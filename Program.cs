using Final_Project.Data;
using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ArenaDbContext>(options =>
    options.UseSqlite("Data Source=arena.db"));

var app = builder.Build();



using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<ArenaDbContext>();
    context.Database.EnsureCreated();


// used AI to generate the data

    if (!context.Players.Any()) {
        var players = new List<Player> {

            new Player { Username = "ShadowBlade", Title = "Dragon Slayer", StrengthLevel = 95, AgilityLevel = 88, IntelligenceLevel = 72, Achievements = "First Blood, Speed Demon, Untouchable" },
            new Player { Username = "IronFist", Title = "Warlord", StrengthLevel = 99, AgilityLevel = 60, IntelligenceLevel = 65, Achievements = "Berserker, Wall Breaker, Last Stand" },
            new Player { Username = "ArcaneWitch", Title = "Grand Mage", StrengthLevel = 45, AgilityLevel = 70, IntelligenceLevel = 99, Achievements = "Spell Weaver, Mind Breaker, Arcane Master" },
            new Player { Username = "SwiftArrow", Title = "Ranger Elite", StrengthLevel = 65, AgilityLevel = 97, IntelligenceLevel = 80, Achievements = "Sharpshooter, Ghost Step, Eagle Eye" },
            new Player { Username = "StoneGuard", Title = "Sentinel", StrengthLevel = 88, AgilityLevel = 50, IntelligenceLevel = 74, Achievements = "Immovable, Shield Wall, Iron Will" },
            new Player { Username = "VoidWalker", Title = "Shadow Lord", StrengthLevel = 80, AgilityLevel = 85, IntelligenceLevel = 90, Achievements = "Phase Shift, Dark Pact, Soul Reaper" },
            new Player { Username = "BloodRaven", Title = "Assassin", StrengthLevel = 78, AgilityLevel = 99, IntelligenceLevel = 68, Achievements = "Silent Kill, Phantom Strike, Death Mark" },
            new Player { Username = "ThunderClad", Title = "Storm Knight", StrengthLevel = 91, AgilityLevel = 75, IntelligenceLevel = 60, Achievements = "Lightning Charge, Thunder Dome, Storm Rider" },
            new Player { Username = "FrostBite", Title = "Ice Witch", StrengthLevel = 55, AgilityLevel = 80, IntelligenceLevel = 95, Achievements = "Frozen Tundra, Blizzard Lord, Cold Snap" },
            new Player { Username = "CrimsonAxe", Title = "Berserker", StrengthLevel = 98, AgilityLevel = 55, IntelligenceLevel = 40, Achievements = "Rampage, Blood Fury, Unstoppable" },
            new Player { Username = "MoonShade", Title = "Night Stalker", StrengthLevel = 70, AgilityLevel = 94, IntelligenceLevel = 82, Achievements = "Moonlit Strike, Shadow Dance, Eclipse" },
            new Player { Username = "RuneScribe", Title = "Archmage", StrengthLevel = 40, AgilityLevel = 60, IntelligenceLevel = 100, Achievements = "Rune Master, Spell Surge, Ancient Knowledge" },
            new Player { Username = "GaleForce", Title = "Wind Runner", StrengthLevel = 60, AgilityLevel = 100, IntelligenceLevel = 70, Achievements = "Gust Strike, Wind Walk, Tempest Dash" },
            new Player { Username = "OakHeart", Title = "Nature Warden", StrengthLevel = 85, AgilityLevel = 65, IntelligenceLevel = 78, Achievements = "Root Bind, Nature's Wrath, Grove Guardian" },
            new Player { Username = "SteelVigor", Title = "Paladin", StrengthLevel = 90, AgilityLevel = 68, IntelligenceLevel = 80, Achievements = "Holy Strike, Divine Shield, Righteous Fury" },
            new Player { Username = "PyroMantle", Title = "Fire Lord", StrengthLevel = 82, AgilityLevel = 72, IntelligenceLevel = 88, Achievements = "Inferno Blast, Magma Core, Flame Dancer" },
            new Player { Username = "DuskReaper", Title = "Reaper", StrengthLevel = 76, AgilityLevel = 88, IntelligenceLevel = 85, Achievements = "Soul Harvest, Grim Touch, Twilight Slash" },
            new Player { Username = "CoralFang", Title = "Sea Warrior", StrengthLevel = 83, AgilityLevel = 79, IntelligenceLevel = 65, Achievements = "Tidal Crush, Deep Dive, Riptide" },
            new Player { Username = "GlacierPeak", Title = "Frost Titan", StrengthLevel = 93, AgilityLevel = 55, IntelligenceLevel = 70, Achievements = "Avalanche, Ice Fortress, Permafrost" },
            new Player { Username = "EmberWing", Title = "Phoenix Rider", StrengthLevel = 77, AgilityLevel = 91, IntelligenceLevel = 75, Achievements = "Rebirth, Flame Dive, Ash Storm" },
            new Player { Username = "TerraShield", Title = "Earth Guardian", StrengthLevel = 96, AgilityLevel = 45, IntelligenceLevel = 72, Achievements = "Earthquake, Stone Wall, Granite Fist" },
            new Player { Username = "NightVeil", Title = "Phantom", StrengthLevel = 68, AgilityLevel = 96, IntelligenceLevel = 87, Achievements = "Vanish, Wraith Form, Specter Slash" },
            new Player { Username = "BoltSurge", Title = "Thunder Mage", StrengthLevel = 58, AgilityLevel = 82, IntelligenceLevel = 97, Achievements = "Chain Lightning, Overcharge, Static Field" },
            new Player { Username = "WildThorn", Title = "Druid", StrengthLevel = 72, AgilityLevel = 76, IntelligenceLevel = 91, Achievements = "Thorned Armor, Wild Growth, Beast Form" },
            new Player { Username = "AshenBlade", Title = "Death Knight", StrengthLevel = 94, AgilityLevel = 78, IntelligenceLevel = 69, Achievements = "Death Strike, Plague Aura, Runic Power" },
        };
        context.Players.AddRange(players);
        context.SaveChanges();
    }

    if (!context.Bosses.Any()) {
        var bosses = new List<Boss> {


            new Boss { Name = "Inferno Drake", Description = "A massive fire-breathing dragon.", StrengthLevel = 95, DefenseLevel = 80, SpeedLevel = 70, LootItems = "Dragon Scale (5%), Fire Gem (10%), Ember Crown (1%)" },
            new Boss { Name = "Void Titan", Description = "An ancient colossus from the void.", StrengthLevel = 99, DefenseLevel = 95, SpeedLevel = 40, LootItems = "Void Shard (8%), Titan Armor (2%), Dark Core (0.5%)" },
            new Boss { Name = "Storm Serpent", Description = "A lightning-infused sea serpent.", StrengthLevel = 85, DefenseLevel = 65, SpeedLevel = 92, LootItems = "Storm Scale (7%), Thunder Fang (3%), Tempest Ring (1%)" },
            new Boss { Name = "Frost Lich", Description = "An undead sorcerer of immense cold power.", StrengthLevel = 80, DefenseLevel = 70, SpeedLevel = 60, LootItems = "Lich Crown (2%), Frozen Soul (6%), Ice Staff (1%)" },
            new Boss { Name = "Shadow Hydra", Description = "A multi-headed serpent born from darkness.", StrengthLevel = 90, DefenseLevel = 75, SpeedLevel = 78, LootItems = "Hydra Scale (9%), Shadow Fang (4%), Dark Venom (2%)" },
            new Boss { Name = "Iron Golem", Description = "A mechanical giant forged in ancient fires.", StrengthLevel = 97, DefenseLevel = 99, SpeedLevel = 25, LootItems = "Iron Core (10%), Golem Fist (3%), Ancient Gear (1%)" },
            new Boss { Name = "Plague Wraith", Description = "A disease-spreading spirit of doom.", StrengthLevel = 72, DefenseLevel = 60, SpeedLevel = 85, LootItems = "Wraith Essence (8%), Plague Mask (2%), Cursed Robe (1%)" },
            new Boss { Name = "Magma Colossus", Description = "A lava giant that erupts with each step.", StrengthLevel = 96, DefenseLevel = 88, SpeedLevel = 35, LootItems = "Magma Core (6%), Lava Stone (12%), Colossus Plate (1%)" },
            new Boss { Name = "Tempest Eagle", Description = "A giant eagle that commands the skies.", StrengthLevel = 78, DefenseLevel = 55, SpeedLevel = 99, LootItems = "Storm Feather (10%), Eagle Talon (5%), Wind Crystal (2%)" },
            new Boss { Name = "Abyssal Leviathan", Description = "A sea monster of unimaginable size.", StrengthLevel = 100, DefenseLevel = 92, SpeedLevel = 65, LootItems = "Leviathan Scale (3%), Abyss Pearl (1%), Deep Fang (7%)" },
        };
        context.Bosses.AddRange(bosses);
        context.SaveChanges();
    }

    if (!context.HighScores.Any()) {
        var highScores = new List<HighScore> {


            new HighScore { PlayerId = 1, BossId = 1, KillCount = 142 },
            new HighScore { PlayerId = 2, BossId = 1, KillCount = 118 },
            new HighScore { PlayerId = 3, BossId = 2, KillCount = 95 },
            new HighScore { PlayerId = 4, BossId = 2, KillCount = 87 },
            new HighScore { PlayerId = 5, BossId = 3, KillCount = 203 },
            new HighScore { PlayerId = 6, BossId = 3, KillCount = 176 },
            new HighScore { PlayerId = 7, BossId = 4, KillCount = 160 },
            new HighScore { PlayerId = 8, BossId = 4, KillCount = 134 },
            new HighScore { PlayerId = 9, BossId = 5, KillCount = 112 },
            new HighScore { PlayerId = 10, BossId = 5, KillCount = 99 },
            new HighScore { PlayerId = 11, BossId = 6, KillCount = 88 },
            new HighScore { PlayerId = 12, BossId = 6, KillCount = 74 },
            new HighScore { PlayerId = 13, BossId = 7, KillCount = 210 },
            new HighScore { PlayerId = 14, BossId = 7, KillCount = 195 },
            new HighScore { PlayerId = 15, BossId = 8, KillCount = 145 },
            new HighScore { PlayerId = 16, BossId = 8, KillCount = 130 },
            new HighScore { PlayerId = 17, BossId = 9, KillCount = 177 },
            new HighScore { PlayerId = 18, BossId = 9, KillCount = 155 },
            new HighScore { PlayerId = 19, BossId = 10, KillCount = 220 },
            new HighScore { PlayerId = 20, BossId = 10, KillCount = 198 },
            new HighScore { PlayerId = 21, BossId = 1, KillCount = 105 },
            new HighScore { PlayerId = 22, BossId = 2, KillCount = 80 },
            new HighScore { PlayerId = 23, BossId = 3, KillCount = 165 },
            new HighScore { PlayerId = 24, BossId = 4, KillCount = 120 },
            new HighScore { PlayerId = 25, BossId = 5, KillCount = 91 },
        };
        context.HighScores.AddRange(highScores);
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();