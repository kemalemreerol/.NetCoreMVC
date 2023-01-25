﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetLast10Blogs()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(u=> u.Category).ToList();
            }
                
        }

        public List<Blog> GetListWithCategory()
        {
            using(var c = new Context())
            {
                return c.Blogs.Include(u => u.Category).ToList();
            }
            
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using(var c = new Context())
            {
                return c.Blogs.Include(u=> u.Category).Where(x=> x.CategoryID==id).ToList();    
            }
        }
    }
}
