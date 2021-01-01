using System;
using System.Collections.Generic;
using System.Text;
using Mineral_Management.Models;
using Mineral_Management.Views;

namespace Mineral_Management.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        public FinalReportOfDailyMineralsIntake Report { get; set; }
        public ReportViewModel(FinalReportOfDailyMineralsIntake report)
        {
            Title = "Minerals daily intake report";
            Report = report;
        }
    }
}
