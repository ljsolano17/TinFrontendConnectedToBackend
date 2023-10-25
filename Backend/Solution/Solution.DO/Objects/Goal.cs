using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Goal
    {
        public int GoalId { get; set; }

        public string GoalName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double? Target { get; set; }

        public bool GoalType { get; set; }

        public int? MetricId { get; set; }

        public int GoalStatusId { get; set; }

        public string? UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
