﻿//using ASM2_AppDev.Data;
//using ASM2_AppDev.Repository.IRepository;

//namespace ASM2_AppDev.Repository
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly ApplicationDBContext _dbContext;
//        public ICategoryRepository CategoryRepository { get; private set; }
//        public IBookRepository BookRepository { get; private set; }
//        public IShoppingCartRepository ShoppingCartRepository { get; private set; }
//        public IOrderHeaderRepository OrderHeader { get; private set; }
//        public IOrderDetailRepository OrderDetails { get; private set; }

//        public UnitOfWork(ApplicationDBContext dBContext)
//        {
//            _dbContext = dBContext;
//            CategoryRepository = new CategoryRepository(dBContext);
//            ShoppingCartRepository = new ShoppingCartRepository(dBContext);
//            BookRepository = new BookRepository(dBContext);
//            OrderDetails = new OrderDetailRepository(dBContext);
//            OrderHeader = new OrderHeaderRepository(dBContext);
        
//        }
//        public void Save()
//        {
//            _dbContext.SaveChanges();
//        }
//    }
//}
