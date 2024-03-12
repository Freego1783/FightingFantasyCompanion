using FightingFantasyCompanion.Shared.Enums;

namespace FightingFantasyCompanion.Shared.Models
{
    public class AdventureSheet
    {
        public string Id { get; set; }
        public BookName Bookname { get;set; }
        public int InitialSkill { get; set; }
        public int Skill { get; set; }
        public int InitialStamina { get; set; }
        public int Stamina { get; set;}
        public int InitialLuck { get; set; }
        public int Luck { get; set; }
        public int Gold { get;set; }
        public int Provisions { get; set; }

        public AdventureSheet()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
