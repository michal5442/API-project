using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PasswordService
    {
        public CheckPassword Check(string pass)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pass);
            int strength = result.Score;
            CheckPassword password = new CheckPassword();
            password.Strength = strength;
            password.Password = pass;
            return password;
        }
    }
}
