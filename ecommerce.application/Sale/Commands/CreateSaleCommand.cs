namespace ecommerce.application.Sale.Commands
{
    sealed class CreateSaleCommand: ICreateSaleCommand
    {
        public CreateSaleCommand()
        {
        }

        public Task ExecuteAsync(CreateSaleModel model, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
