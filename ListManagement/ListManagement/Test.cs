using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement
{
    internal class Test
    {
        public Test()
        {
            var listSrv = ItemService.Current;
            listSrv.Add(new models.Item { Name = "Test1" });
            var listSrv2 = ItemService.Current;

            foreach (var item in listSrv2.Items)
            {
                Console.WriteLine(item);
            }
        }


    }
}
