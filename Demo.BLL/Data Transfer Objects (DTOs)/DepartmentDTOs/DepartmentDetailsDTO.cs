﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Data_Transfer_Objects__DTOs_
{
    public class DepartmentDetailsDTO
    {
        #region BaseEntity Properties
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User Id
        public DateOnly? CreatedOn { get; set; } // Date Time
        public int ModifiedBy { get; set; } // User Id
        public DateOnly? ModifiedOn { get; set; } // Date Time
        public bool IsDeleted { get; set; } // Soft Delete
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        #endregion
    }
}
