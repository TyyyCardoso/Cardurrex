using System.ComponentModel.DataAnnotations.Schema;

namespace CardurrexAPI.Models
{
    public class BarbecueGames
    {
        /// <summary>
        /// Identificador principal da relação entre churrascos e jogos
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do churrasco
        /// </summary>
        [ForeignKey("Barbecue")]
        public int BarbecueID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do jogo
        /// </summary>
        [ForeignKey("Game")]
        public int GameID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do utilizador que ganhou o jogo
        /// </summary>
        [ForeignKey("User")]
        public string? Winner { get; set; }

        /// <summary>
        /// Navigation properties (optional)
        /// </summary>
        public virtual Barbecues Barbecue { get; set; }
        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
