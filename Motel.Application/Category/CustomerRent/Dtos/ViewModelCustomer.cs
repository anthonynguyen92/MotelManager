using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.Application.Category.CustomerRent.Dtos
{
    public class ViewModelCustomer<T>
    {
        public List<T> item;
        public int totalRecord;
    }
}
