using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    class House
    {
        public House()
        {
            Parts = new List<IPart>();
        }
        public List<IPart> Parts { get; private set; } = new List<IPart>();
        
        public void AddPart(IPart part)
        {
            if(part != null)
            {
                Parts.Add(part);
            }
        }
        public House(List<IPart> parts)
        {
            if(parts != null)
            {
                Parts = parts;
            }
        }
    }
}
