using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public void Add(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public Country GetById(int id)
        {
            throw new NotImplementedException();
        }
        public string GetName(int id)
        {
            return _countryDal.Get(z=>z.Id == id).Name;
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
