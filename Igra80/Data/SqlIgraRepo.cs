using Igra80.Models;
using System.Collections.Generic;
using System.Linq;

namespace Igra80.Data
{
    public class SqlIgraRepo : IIgraRepo
    {
        private readonly IgraContext _context;
        

        public SqlIgraRepo(IgraContext context)
        {
            _context = context;
        }
        public IEnumerable<Incidence> GetAllIncidences()
        {
            return _context.igra80.ToList();
        }

        public Incidence GetIncidenceByCaId(int caid)
        {
            return _context.igra80.FirstOrDefault(i => i.CaId == caid);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        
    }
}
