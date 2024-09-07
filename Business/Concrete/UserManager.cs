using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Conccrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            return _userDal.List();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }
        public string GetName(int id)
        {
            return _userDal.Get(x=> x.Id == id).FirstName;
        }public string GetLastName(int id)
        {
            return _userDal.Get(x=> x.Id == id).LastName;
        }

        public void Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
