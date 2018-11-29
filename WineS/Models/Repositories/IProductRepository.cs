using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineS.Entities;

namespace WineS.Models.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        Product getProduct(int Id);



        void SaveProduct(Product product);
        Product DeleteProduct(int Id);

    }
}
