using DTO.Entities;
using DTO.Entities.Base;
using System.Collections.Generic;

namespace DTO
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public string TradingName { get; private set; }
        public Address Address { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public Supplier() { }

        public Supplier(string companyName, string cnpj, string tradingName, string telephone, string email, Address address)
        {
            CompanyName = companyName;
            Cnpj = cnpj;
            TradingName = tradingName;
            Address = address;
            Telephone = telephone;
            Email = email;
        }
    }
}