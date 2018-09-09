using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Repository
{
    public class AfterSellExpencessRepo : IAfterSellExpncess
    {
        public Dictionary<int, AfterSellExpncess> Persons;
        CarMangerContext _context;
        List<AfterSellExpncess> lss;

        public AfterSellExpencessRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, AfterSellExpncess>();
            lss = _context.AfterSellExpncess.OrderBy(a => a.Date).ToList();
            lss.ForEach(action: async r => await AddAfterSellExpncess(r));
        }

        
        AfterSellExpncess IAfterSellExpncess.this[int Id] => Persons.ContainsKey(Id)? Persons[Id] : null;

        
       public IQueryable<AfterSellExpncess> GetallSellExpncesses =>  Persons.Values.AsQueryable();


      

        public async Task AddAfterSellExpncess(AfterSellExpncess afterSellExpncess)
        {
            if (afterSellExpncess.Id==0)
            {
                try
                {
                    _context.AfterSellExpncess.Add(afterSellExpncess);
              
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }
            Persons[afterSellExpncess.Id] = afterSellExpncess;
        }

        public void DeleteAfterSellExpncessr(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAfterSellExpncess(AfterSellExpncess afterSellExpncess)
        {
            throw new NotImplementedException();
        }
    }
}
