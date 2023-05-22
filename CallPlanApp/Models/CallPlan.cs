using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallPlanApp.Models
{
    public partial class CallPlan
    {
        public int Id { get; set; }
        [DisplayName("NAME")]
        public string Name { get; set; } = null!;
        [DisplayName("START DATE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayName("VISIT TYPE")]
        public string VisitType { get; set; } = null!;
        [DisplayName("COMPLETE")]
        public bool Complete { get; set; }
    }
}
