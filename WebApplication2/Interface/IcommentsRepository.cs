using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Interface
{
    interface IcommentsRepository
    {
        IEnumerable<Comments> GetAll();
        Comments Get(int id);
        Comments Add(Comments item);
        bool Update(Comments item);
        bool Delete(int id);


    }
}