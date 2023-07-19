using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks2Web
{
    public interface IStockBot
    {
        string CheckStock(string key);
    }
}
