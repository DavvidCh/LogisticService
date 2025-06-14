using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Dtos
{
    public class ContainerDto
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public decimal Coefficient { get; set; }

        public ContainerDto(int id, bool isClosed, decimal coefficient)
        {
            Id = id;
            IsClosed = isClosed;
            Coefficient = coefficient;
        }

        public ContainerDto()
        {
        }
    }
}
