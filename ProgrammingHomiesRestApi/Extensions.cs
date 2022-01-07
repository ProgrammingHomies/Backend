using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using phra.Dtos.PostDtos;
using ProgrammingHomiesRestApi.Dtos.UserDtos;
using ProgrammingHomiesRestApi.Entities;
using System.Security.Cryptography;

namespace ProgrammingHomiesRestApi
{
    public static class Extensions
    {
        public static UserDto AsDto(this User item)
        {
            return new UserDto
            {
                Id = item.Id,
                Biography = item.Biography,
                BirthDate = item.BirthDate,
                Mail = item.Mail,
                Password = item.Password,
                ProfilePhotoUrl = item.ProfilePhotoUrl,
                Username = item.Username,
            };
        }

        public static PostDto AsDto(this Post item)
        {
            return new PostDto
            {
                Id = item.Id,
                EndTime = item.EndTime,
                PostUser = item.PostUser,   
                Text = item.Text,
                Title= item.Title,
            };
        }

        public static string ToHash(this string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
