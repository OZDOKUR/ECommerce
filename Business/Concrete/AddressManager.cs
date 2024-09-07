using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddresDal _addresDal;
        private readonly ICountryDal _countryDal;
        private readonly IStateDal _stateDal;
        private readonly ICityDal _cityDal;

        public AddressManager(IAddresDal addresDal)
        {
            _addresDal = addresDal;
        }
        public AddressManager(IAddresDal addresDal, ICityDal cityDal, ICountryDal countryDal, IStateDal stateDal)
        {
            _addresDal = addresDal;
            _countryDal = countryDal;
            _stateDal = stateDal;
            _cityDal = cityDal;
        }

        public void Add(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            return _addresDal.List();
        }

        public Address GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetUserAddress(int user)
        {
            return _addresDal.List(a => a.UserId == user);
        }
        public string GetCountryName(int id)
        {
            var addressId = _addresDal.Get(a => a.Id == id);
            var countryId = addressId.CountryId;
            var countryName = _countryDal.Get(x => x.Id == countryId).Name;
            return countryName;
        }
        public string GetStatesName(int id)
        {
            var addressId = _addresDal.Get(a => a.Id == id);
            var stateId = addressId.StateId;
            var stateName = _stateDal.Get(s => s.Id == stateId).Name;
            return stateName;
        }
        public string GetAddresDesc(int id)
        {
            var address = _addresDal.Get(a => a.Id == id).AddressLine1;
            return address;
        }public string GetAddres2Desc(int id)
        {
            var address = _addresDal.Get(a => a.Id == id).AddressLine2;
            return address;
        }
        public void Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
