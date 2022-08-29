using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace WebAPI_Systemutveckling_.Net.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class AccountEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;
        [Required, Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;
        [Required, Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = null!;
        [Required, Column(TypeName = "varbinary(max)")]
        public byte[] Hash { get; set; } = null!;
        [Required, Column(TypeName = "varbinary(max)")]
        public byte[] Salt { get; set; } = null!;

        /// <summary>
        /// Create new Password for User Account
        /// </summary>
        /// <param name="password">A unicode password</param>


        public void CreatePassword(string password)
        {
            using var hmac = new HMACSHA512();
            Salt = hmac.Key;
            Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidatePassword(string password)
        {
            using var hmac = new HMACSHA512(Salt);
            Salt = hmac.Key;
            var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < Hash.Length; i++)
                if (_hash[i] != Hash[i])
                    return false;

            return true;
        }
    }
}
