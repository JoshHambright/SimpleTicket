using SimpleTicket.Data;
using SimpleTicket.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SimpleTicket.Services
{
    //© 2021 - Josh Hambright

    public class NoteService
    {

        private readonly Guid _userID;

        public NoteService(Guid userID)
        {
            _userID = userID;
        }

        //Create 
        public async Task<bool> CreateNoteAsync(NoteCreate model)
        {
            var entity = new Note()
            {
                Creator = _userID,
                Body = model.Body,
                DateCreate = DateTimeOffset.Now,
                CreateName = System.Web.HttpContext.Current.User.Identity.Name,
                TicketID = model.TicketID
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Read All
        public async Task<IEnumerable<NoteListItem>> GetNotesAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Notes
                            //.Where()
                            .OrderBy(e => e.TicketID)
                            .ThenBy(e => e.DateCreate)
                            .Select(
                                e =>
                                    new NoteListItem
                                    {
                                        ID = e.ID,
                                        CreatorName = e.CreateName,
                                        BodyShort = e.Body.Substring(0, 50) + "...",
                                        DateCreate = e.DateCreate,
                                        DateUpdated = e.DateUpdated
                                    }
                                ).ToListAsync();
                return query;
            }
        }

        //Read all by TicketID
        public async Task<IEnumerable<NoteListItem>> GetNotesByTicketAsync(Guid ticketID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Notes
                            .Where(e => e.TicketID == ticketID)
                            .OrderBy(e => e.DateUpdated)
                            .ThenBy(e => e.ID)
                            .Select(
                                e =>
                                    new NoteListItem
                                    {
                                        ID = e.ID,
                                        CreatorName = e.CreateName,
                                        BodyShort = e.Body.Substring(0, 50) + "...",
                                        DateCreate = e.DateCreate,
                                        DateUpdated = e.DateUpdated
                                    }
                                ).ToListAsync();
                return query;
            }
        }

        //Read Details by NoteID
        public async Task<NoteDetail> GetNoteByIDAsync(int noteID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                            ctx
                            .Notes
                            .Where(e => e.ID == noteID)
                            .FirstOrDefaultAsync();
            return
                new NoteDetail
                {
                    ID = entity.ID,
                    CreatorName = entity.CreateName,
                    Creator = entity.Creator,
                    Body = entity.Body,
                    DateCreate = entity.DateCreate,
                    DateUpdated = entity.DateUpdated,
                    TicketID = entity.TicketID,
                    TicketName = entity.Ticket.Title
                };
            }
        }

        //Update
        public async Task<bool> UpdateNoteAsync(NoteEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Notes
                                .Where(e => e.ID == note.ID
                                            && e.Creator == _userID)
                                .FirstOrDefaultAsync();
                entity.Body = note.Body;
                entity.DateUpdated = DateTimeOffset.Now;
                entity.TicketID = note.TicketID;
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Delete
        public async Task<bool> DeleteNoteAsync(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                                ctx
                                .Notes
                                .Where(e => e.ID == ID)
                                .FirstOrDefaultAsync();
                ctx.Notes.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
