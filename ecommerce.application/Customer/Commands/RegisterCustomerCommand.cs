using ecommerce.core;
using LanguageExt;

namespace ecommerce.application.Customer.Commands
{
    using domain.Entities.Customers;
    using ecommerce.core.Commands;

    internal class RegisterCustomerCommand : IRegisterCustomerCommand
    {
        readonly ICustomerFactory _customerFactory;
        readonly IDatabaseService _databaseService;

        public RegisterCustomerCommand(IDatabaseService databaseService, ICustomerFactory customerFactory)
        {
            _databaseService= databaseService;
            _customerFactory = customerFactory;
        }

        public async Task Execute(RegisterCustomerModel model)
        {
            //optimistic behaivior
            await using (var transaction = _databaseService.BeginTransaction())
            {
                try
                {
                    var entityResult = _customerFactory.Create(model.FirstName, model.LastName)
                        .Bind<Customer>(
                            entity =>
                            {
                                _databaseService.Customers.Add(entity);
                                _databaseService.SaveChanges();
                                return entity;
                            });
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();  
                }
            }
        }

        
        public Task ExecuteAsync<M>() where M : class
        {
            throw new NotImplementedException();
        }
    }
}
