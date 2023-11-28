public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddProduct(Product product)
    {
        _unitOfWork.Products.Add(product);
        _unitOfWork.Complete();
    }

    // Similarly, you can add methods for Get, Update, and Delete
}
