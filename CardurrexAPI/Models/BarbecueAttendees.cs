using System.ComponentModel.DataAnnotations.Schema;

namespace CardurrexAPI.Models
{
    public class BarbecueAttendees
    {
        /// <summary>
        /// Identificador principal da relação entre os churrascos e os convidados
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do churrasco
        /// </summary>
        [ForeignKey("Barbecue")]
        public int BarbecueID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do utilizador
        /// </summary>
        [ForeignKey("User")]
        public string UserID { get; set; }
        /// <summary>
        /// Identificador estrangeiro do estado do convite do convidado
        /// </summary>
        [ForeignKey("BarbecueAttendeeStatus")]
        public int? Status { get; set; }
        /// <summary>
        /// Número de pessoas extra que o convidado irá levar
        /// </summary>
        public int NumberOfGuests { get; set; }

        /// <summary>
        /// Navigation properties (optional)
        /// </summary>
        public virtual Barbecues Barbecue { get; set; }
        public virtual Users User { get; set; }
        public virtual BarbecueAttendeesStatus BarbecueAttendeeStatus { get; set; }
    }
}
