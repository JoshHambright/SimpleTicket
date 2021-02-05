using SimpleTicket.Data;
using SimpleTicket.Models.NoteModels;
using SimpleTicket.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SimpleTicket.Services
{
    public class TicketService
    {

        private readonly Guid _userID;

        public TicketService(Guid userID)
        {
            _userID = userID;
        }

        //Create
        public async Task<bool> CreateTicketAsync(TicketCreate ticket)
        {
            var entity = new Ticket()
            {
                CreatorID = _userID,
                CreatorName = HttpContext.Current.User.Identity.Name,
                Title = ticket.Title,
                Description = ticket.Description,
                CustomerID = ticket.CustomerID,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
                Priority = ticket.Priority,
                Status = ticket.Status
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Read All
        public async Task<IEnumerable<TicketListItem>> GetTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Tickets
                            .OrderBy(e => e.Status)
                            .ThenByDescending(e => e.Priority)
                            .ThenByDescending(e => e.DateCreated)
                            .Select(
                                e =>
                                    new TicketListItem
                                    {
                                        TicketID = e.TicketID,
                                        CreatorID = e.CreatorID,
                                        CreateName = e.CreatorName,
                                        Title = e.Title,
                                        CustomerID = e.CustomerID,
                                        CustomerName = e.Customer.Name,
                                        DateCreated = e.DateCreated,
                                        DateUpdated = e.DateUpdated,
                                        NoteCount = e.Notes.Count,
                                        Priority = e.Priority,
                                        Status = e.Status
                                    }
                                ).ToListAsync();
                return query;
            }
        }

        //Read Details
        public async Task<TicketDetail> GetTicketByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                            ctx
                            .Tickets
                            .Where(e => e.TicketID == id)
                            .FirstOrDefaultAsync();
                return
                    new TicketDetail
                    {
                        TicketID = entity.TicketID,
                        CreatorID = entity.CreatorID,
                        CreatorName = entity.CreatorName,
                        Title = entity.Title,
                        Description = entity.Description,
                        CustomerID = entity.CustomerID,
                        CustomerName = entity.Customer.Name,
                        DateCreated = entity.DateCreated,
                        DateUpdated = entity.DateUpdated,
                        NoteCount = entity.Notes.Count,
                        Notes = entity.Notes
                                        .Select(
                                                f =>
                                                new NoteListItem
                                                {
                                                    ID = f.ID,
                                                    CreatorName = f.CreateName,
                                                    BodyShort = f.Body.Substring(0, 50),
                                                    DateCreate = f.DateCreate,
                                                    DateUpdated = f.DateUpdated
                                                }
                                                ).ToList(),
                        Priority = entity.Priority,
                        Status = entity.Status
                    };
            }
        }

        public async Task<bool> UpdateTicketByID(TicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Tickets
                                .Where(e => e.TicketID == model.TicketID)
                                .FirstOrDefaultAsync();
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.CustomerID = model.CustomerID;
                entity.Priority = model.Priority;
                entity.Status = model.Status;
                entity.DateUpdated = DateTimeOffset.Now;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteNoteAsync(Guid ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Tickets
                                .Where(e => e.TicketID == ID)
                                .FirstOrDefaultAsync();
                ctx.Tickets.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
