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
        [Required(ErrorMessage = "This is required.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "This is required.")]
        [DisplayName("START DATE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "This is required.")]
        [DisplayName("VISIT TYPE")]
        public string VisitType { get; set; } = null!;
        [Required(ErrorMessage = "This is required.")]
        [DisplayName("COMPLETE")]
        public bool Complete { get; set; }
    }
}
