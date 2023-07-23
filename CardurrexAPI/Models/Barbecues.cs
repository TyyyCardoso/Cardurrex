using System.ComponentModel.DataAnnotations;

namespace CardurrexAPI.Models
{
    public class Barbecues
    {
        /// <summary>
        /// Identificador principal dos churrascos
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Nome do churrasco
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Data e hora do churrasco
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Localização do churrasco
        /// </summary>
        public string? Location { get; set; }
        /// <summary>
        /// Organizador do churrasco
        /// </summary>
        public string? Host { get; set; }
        /// <summary>
        /// Descrição do churrasco
        /// </summary>
        public string? Description { get; set; }

    }
}
