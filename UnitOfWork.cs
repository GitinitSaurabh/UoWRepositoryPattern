public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    public IRepository<Product> Products { get; private set; }

    public UnitOfWork(DbContext context)
    {
        _context = context;
        Products = new Repository<Product>(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
