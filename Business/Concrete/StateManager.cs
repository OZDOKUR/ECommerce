using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Conccrete
{
    public class StateManager : IStateService
    {
        private readonly IStateDal _stateDal;

        public StateManager(IStateDal stateDal)
        {
            _stateDal = stateDal;
        }

        public void Add(State entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(State entity)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAll()
        {
            throw new NotImplementedException();
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }
        public string GetName(int id)
        {
            return _stateDal.Get(z => z.Id == id).Name;
        }

        public void Update(State entity)
        {
            throw new NotImplementedException();
        }
    }
}
