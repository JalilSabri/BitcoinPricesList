using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Domain.Models.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
