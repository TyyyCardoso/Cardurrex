using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CardurrexAPI.Models
{
    public class Users : IdentityUser
    {
        /// <summary>
        /// Primeiro nome do utilizador
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Ultimo nome do utilizador
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Gênero do utilizador
        /// </summary>
        [DataType(DataType.Text)]
        public char Gender { get; set; }
        /// <summary>
        /// Nome da imagem associada ao utilizador (guardada no servidor)
        /// </summary>
        public string? ProfilePicture { get; set; }
        /// <summary>
        /// Data de criação de conta
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Data de ultimo login
        /// </summary>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// Número de vezes que já apareceu em churrascos
        /// </summary>
        public int NumberOfAppearances { get; set; }
        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime BirthDate { get; set; }

    }
}
