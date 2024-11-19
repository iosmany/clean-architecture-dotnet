
namespace ecommerce.application.Sale;

using ecommerce.domain.Entities.Sales;

public class CustomerSaleModel
{
    public CustomerSaleModel() { }
    internal CustomerSaleModel(Sale sale)
    {
        Id = sale.Id;
        CustomerName = sale.Customer.Name.FirstName;
        CustomerEmail = sale.Customer.Email.Value;
        Street = sale.Address.Street;
        City = sale.Address.City;
        State = sale.Address.State;
        CountryCode = sale.Address.Country.Id;
        Country = sale.Address.Country.Name;
        ZipCode = sale.Address.ZipCode;
        Phone = sale.Address.Phone;
        SaleDate = sale.Date;

    }

    public long Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string CountryCode { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    
    public DateTimeOffset SaleDate { get; set; }

}
