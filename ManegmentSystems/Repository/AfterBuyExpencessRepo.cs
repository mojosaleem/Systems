using ManegmentSystems.Models;
using ManegmentSystems.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Repository
{
    public class AfterBuyExpencessRepo : IAfterBuyExpncess
    {
        public Dictionary<int, AfterBuyExpencess> Persons;
        CarMangerContext _context;
        List<AfterBuyExpencess> lss;

        public AfterBuyExpencessRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, AfterBuyExpencess>();
            lss = _context.AfterBuyExpencess.OrderBy(a => a.Date).ToList();
            lss.ForEach(action: async r => await AddAfterBuyExpncessAsync(r));
        }

        public AfterBuyExpencess this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<AfterBuyExpencess> GetAfterBuyExpncesses => Persons.Values.AsQueryable();

        public async Task AddAfterBuyExpncessAsync(AfterBuyExpencess afterBuyExpncess)
        {
            if (afterBuyExpncess.Id==0)
            {
                try
                {
                    afterBuyExpncess.Date = new DateTime().Date.Date;
                    _context.AfterBuyExpencess.Add(afterBuyExpncess);
              
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }
            Persons[afterBuyExpncess.Id] = afterBuyExpncess;
        }

        public void DeleteAfterBuyExpncessr(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAfterBuyExpncess(AfterBuyExpencess afterBuyExpncess)
        {
            throw new NotImplementedException();
        }
    }
}
