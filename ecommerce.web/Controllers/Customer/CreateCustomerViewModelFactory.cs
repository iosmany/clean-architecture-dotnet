namespace ecommerce.web.Controllers.Customer
{
    public interface ICreateCustomerViewModelFactory
    {
        RegisterCustomerViewModel Create();
    }   

    sealed class CreateCustomerViewModelFactory : ICreateCustomerViewModelFactory
    {

        public RegisterCustomerViewModel Create()
        {
            return new RegisterCustomerViewModel();
        }
    }
}
