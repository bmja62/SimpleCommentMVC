using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class CommentsController : ApiController
    {
        static readonly IcommentsRepository repository = new CommentsRepository();

        public string GetAllComments()
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(repository.GetAll().ToList()).ToString();


        }

        public Comments Postcomments(Comments item)
        {
            item.Submit_date = DateTime.Now;
            return repository.Add(item);
        }

        public IEnumerable<Comments> Putcomments(int id, Comments comm)
        {
            comm.Id = id;
            if (repository.Update(comm))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool Deletecomments(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
