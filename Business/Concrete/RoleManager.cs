using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Conccrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(ApplicationRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ApplicationRole entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
