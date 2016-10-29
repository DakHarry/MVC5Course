using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        ////override + tab + space
        //public override IQueryable<Product> All()
        //{
        //    return base.All().Take(50);
        //}
        //¦Û¦æÂX¥RReposity API
        public Product Find(int id)
        {
          return  this.All().FirstOrDefault(p => p.ProductId == id);
            
        }
        public override void Delete(Product product)
        {
            product.IdDeleted = true;
        }

    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}