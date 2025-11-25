using Entities;
using Repositories;
using WebAopiShop;

namespace Services;

public class UserService
    {

        private readonly UserRepository repository = new UserRepository();
        private readonly PasswordService service = new PasswordService();

        public User GetUserById(int id) 
        { 
            return repository.GetUserById(id);
        }

        public User AddUser(User user)
        { 
            if(service.Check(user.Password).Strength<2)
            {
                return null;
            }
            else
            {
            return repository.AddUser(user);
            }        
        }

        public void UpdateUser(User user, int id)
        {
            repository.UpdateUser(id, user);
        }

        public User LogIn(ExistUser user)
        {
            return repository.LogIn(user);
        }


}

