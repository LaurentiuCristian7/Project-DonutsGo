using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.DataAccess
{
    public class DataAccessDemo :IDataAccessDemo
    {
        public DataAccessDemo()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }

    public interface IDataAccessDemo
    {
        public Guid Id { get; set; }
    }
}
