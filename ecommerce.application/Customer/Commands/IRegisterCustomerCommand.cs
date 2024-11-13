using ecommerce.core;
using ecommerce.core.Commands;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Customer.Commands
{
    public interface IRegisterCustomerCommand 
    {
        Task ExecuteAsync(RegisterCustomerModel model);
    }   
}
