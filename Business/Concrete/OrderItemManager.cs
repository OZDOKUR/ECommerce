using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public void Add(OrderItem entity)
        {
            _orderItemDal.Add(entity);
        }

        public void Delete(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }public List<OrderItem> GetAllByOrderId(int id)
        {
            return _orderItemDal.List(x=> x.OrderId == id);
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
