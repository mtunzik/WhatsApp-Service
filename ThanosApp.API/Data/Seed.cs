using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data {
    public class Seed {
        public static void SeedUsers (DataContext context) {
            if (!context.Users.Any ()) {
                var userData = System.IO.File.ReadAllText ("Data/seed/user_seed.json");
                var users = JsonConvert.DeserializeObject<List<User>> (userData);

                foreach (var user in users) {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash ("Password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt ;
                    user.Username = user.Username.ToLower();
                    user.Gender = new Gender {
                        Description = "Male" 
                    };
                    user.DateCreated = DateTime.Now ;
                    user.LastActive = DateTime.Now.AddDays(-2);

                    context.Users.Add(user);

                }
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }
    }
}