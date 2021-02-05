using SimpleTicket.Data;
using SimpleTicket.Models.CustomerModels;
using SimpleTicket.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Services
{
    public class CustomerService
    {

        private readonly Guid _userID;

        public CustomerService(Guid userID)
        {
            _userID = userID;
        }

        //Create
        public async Task<bool> CreateCustomerAsync(CustomerCreate model)
        {
            var entity = new Customer()
            {
                Name = model.Name,
                Status = CustomerStatus.Active
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Read (all)
        //Returns a list of all customers
        //Defaults sorted by Customer Name
        public async Task<IEnumerable<CustomerList>> GetCustomersAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Customers
                            .Where(e => e.Status == CustomerStatus.Active)
                            .OrderBy(e => e.Name) //Sorts by name
                            .Select(
                                e =>
                                    new CustomerList
                                    {
                                        ID = e.ID,
                                        Name = e.Name,
                                        TotalTicketCount = e.Tickets.Count(),
                                        OpenTicketCount = e.Tickets
                                                        .Where(f => f.Status == Status.Open)
                                                        .Select(
                                                                f =>
                                                                    new Models.TicketModels.TicketList
                                                                    {
                                                                        TicketID = f.TicketID,
                                                                        Status = f.Status
                                                                    }
                                                                ).ToList().Count()
                                    }
                                ).ToListAsync();
                return query;
            }
        }

        //Read (by ID)
        public async Task<CustomerDetail> GetCustomerByIDAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                    .Customers
                    .Where(e => e.ID == id)
                    .FirstOrDefaultAsync();
                return
                    new CustomerDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Tickets = entity
                                    .Tickets
                                    .Select
                                    (
                                        f =>
                                            new TicketListShort
                                            {
                                                TicketID = f.TicketID,
                                                CreatorID = f.CreatorID,
                                                Title = f.Title,
                                                DateCreated = f.DateCreated,
                                                DateUpdated = f.DateUpdated,
                                                Priority = f.Priority,
                                                Status = f.Status
                                            }
                                    ).ToList()
                    };
            }
        }

        //Update
        public async Task<bool> UpdateCustomerAsync(CustomerEdit customer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Customers
                                .Where(e => e.ID == customer.ID)
                                .FirstOrDefaultAsync();
                entity.Name = customer.Name;
                entity.Status = customer.Status;
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Delete
        public async Task<bool> SoftDeleteCustomerAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Customers
                                .Where(e => e.ID == id)
                                .FirstOrDefaultAsync();
                entity.Status = CustomerStatus.Deactivated;
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> HardDeleteCustomerAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Customers
                        .Where(e => e.ID == id)
                        .FirstOrDefaultAsync();
                ctx.Customers.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

    }
}


