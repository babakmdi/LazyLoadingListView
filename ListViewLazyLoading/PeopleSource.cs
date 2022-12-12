using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListViewLazyLoading
{

    // Be sure to include the using at the top of the file:
    //using Microsoft.Toolkit.Uwp;

    public class Person
    {
        public string Name { get; set; } 
    }

    public class PeopleSource : IIncrementalSource<Person>
    {
        private readonly List<Person> people;

        public PeopleSource()
        { 
            people = new List<Person>(); 
        }         

        int lasti=1 ;
        public async Task<IEnumerable<Person>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        { 
            var result = (from p in people select p).Skip(pageIndex * pageSize).Take(pageSize); 
            for (int i = 1; i <= 50; i++)
            {
                var p = new Person { Name = "Person " + lasti++ };
                people.Add(p); 
            }
            // Simulates a longer request...
            await Task.Delay(1000);
            //var count = result.Count();
            return result;
        }
    }


}
