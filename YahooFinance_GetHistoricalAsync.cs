using System;
using UiPath.CodedWorkflows;
using YahooFinanceApi;
using System.Data;

namespace finanaceCSharp
{
    public class YahooFinance_GetHistoricalAsync : CodedWorkflow
    {
        [Workflow]
        public (DataTable datatable,string args) Execute(string ticket)
        {
            var history_tab = Yahoo.GetHistoricalAsync(ticket, new DateTime(2021, 1, 1), new DateTime(2022, 1, 1), Period.Daily).Result;
            
            return (datatable: history_tab.ToDataTable(), args: string.Empty);
        }
    }
}