using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class CommentsRepository:IcommentsRepository
    {
        LeanlinkingEntities db = new LeanlinkingEntities();

        public IEnumerable<Comments> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return db.Comments;
        }

        public Comments Get(int id)
        {
            // TO DO : Code to find a record in database
            return db.Comments.Find(id);
        }

        public Comments Add(Comments item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            db.Comments.Add(item);
            db.SaveChanges();
            return item;
        }

        public bool Update(Comments item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            var Comm = db.Comments.Single(a => a.Id == item.Id);
            Comm.Text = item.Text;
            Comm.File_name = item.File_name;
            Comm.File_content = item.File_content;
            Comm.Submit_date = DateTime.Now;
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Comments products = db.Comments.Find(id);
            db.Comments.Remove(products);
            db.SaveChanges();
            return true;
        }





    }
}