using Demo.Models;
using Demo.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class ReportServices
    {
        public static List<Demo.Models.Application> GetApplications()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                context.Users.ToList();
                context.Equipment.ToList();
                context.Malfunctions.ToList();
                var result = context.Applications.ToList();
                return result;
            }
        }
        public static List<Report> GetReports()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                context.Applications.ToList();
                var result = context.Reports.ToList();
                return result;
            }
        }

        public static TimeSpan CalculateAverageTime(List<TimeSpan> timeSpans)
        {
            TimeSpan total = TimeSpan.Zero;
            foreach (var timeSpan in timeSpans)
            {
                total += timeSpan;
            }

            TimeSpan average = TimeSpan.FromTicks(total.Ticks / timeSpans.Count);
            return average;
        }
        public static TimeSpan GetAverageReportTime()
        {
            List<Report> reports = GetReports();
            List<TimeOnly?> leadTime = reports.Select(r => r.LeadTime).ToList();
            List<TimeSpan> reportTimes = leadTime.Where(leadTime => leadTime.HasValue)
                .Select(leadTime => new TimeSpan(leadTime.Value.Hour, leadTime.Value.Minute, leadTime.Value.Second))
                .ToList();
            TimeSpan averageTime = CalculateAverageTime(reportTimes);
            return averageTime;
        }
    }
}
