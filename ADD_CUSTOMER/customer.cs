using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ADD_CUSTOMER
{
    public class customer
    {
        public int id {  get; set; }
        public string name {  get; set; }
        public string family {  get; set; }
        public string customer_id { get; set; }
        public string product_name {  get; set;}
        public string product_model {  get; set;}
        public string description {  get; set;}
        
        //افعال crud(creat read delete update)

        public bool exist() 
        {
            Db db= new Db();
            var a=db.customers.Where(i=>i.customer_id==customer_id);
            if (a.Count() == 1)
            {
                return true;
            }
            else
                return false;
            
        }
        public customer read(customer form) //ثبت نام
        {
            
                if (!exist()) 
                {
                Db db= new Db();
                db.customers.Add(form);
                db.SaveChanges();
                return form;
                }
                return form;
        }
        public List<customer> read(string text) //search
        {
            return (from i in (new Db()).customers where i.name.Contains(text) || i.family.Contains(text) || 
                    i.product_name.Contains(text) || i.product_model.Contains(text) ||i.customer_id.Contains(text) 
                    select i).ToList();
        }
        public customer read(int id) //search by id
        {
            return (from i in (new Db()).customers where i.id == id select i).Single();
        }
        public List<customer> read() //read all
        {
            return ((new Db()).customers).ToList();
        }
        public void update(int id,customer customer) 
        {
        if (!exist()) 
            {
            Db db= new Db();
                var a = db.customers.Where(i => i.id == id);
                if (a.Count() == 1) 
                {
                    customer c =new customer();
                    c=a.SingleOrDefault();
                    c.name= customer.name;
                    c.family=customer.family;
                    c.customer_id=customer.customer_id;
                    c.product_name=customer.product_name;
                    c.product_model=customer.product_model;
                    c.description=customer.description;
                    db.SaveChanges();
                }
            }
        }
        public void delete(int id) 
        {
        Db db= new Db();
            var a = db.customers.Where(i => i.id == id);
            if (a.Count() == 1) 
            {
                db.customers.Remove(a.Single());
                db.SaveChanges();
            }
        }
    }
    }
