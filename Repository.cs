public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    public Repository(DbContext context)
    {
        Context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    public T Get(int id)
    {
        return Context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}
