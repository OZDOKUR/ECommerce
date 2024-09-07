using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _orderDal.List();
        }

        public Order GetById(int id)
        {
            return _orderDal.GetById(p => p.Id == id);
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }


    }

}
