namespace CardurrexAPI.Models
{
    public class Games
    {
        /// <summary>
        /// Identificador principal de cada jogo
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome do jogo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Breve descrição de como o jogo funciona
        /// </summary>
        public string Description { get; set; }

    }
}
