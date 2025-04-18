using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models.Shared
{
    public class BaseEntity
    {

        #region BaseEntity Properties
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User Id
        public DateTime? CreatedOn { get; set; } // Date Time
        public int ModifiedBy { get; set; } // User Id
        public DateTime? ModifiedOn { get; set; } // Date Time
        public bool IsDeleted { get; set; } // Soft Delete
        #endregion

    }
}
