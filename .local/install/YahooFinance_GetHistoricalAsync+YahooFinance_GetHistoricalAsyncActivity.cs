using System.Activities;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Utils;
using System;
using YahooFinanceApi;
using System.Data;

namespace finanaceCSharp
{
    public class YahooFinance_GetHistoricalAsyncActivity : System.Activities.Activity
    {
        public InArgument<string> ticket { get; set; }

        public OutArgument<DataTable> datatable { get; set; }

        public OutArgument<string> args { get; set; }

        public YahooFinance_GetHistoricalAsyncActivity()
        {
            this.Implementation = () =>
            {
                return new YahooFinance_GetHistoricalAsyncActivityChild()
                {ticket = (this.ticket == null ? (InArgument<string>)Argument.CreateReference((Argument)new InArgument<string>(), "ticket") : (InArgument<string>)Argument.CreateReference((Argument)this.ticket, "ticket")), datatable = (this.datatable == null ? (OutArgument<DataTable>)Argument.CreateReference((Argument)new OutArgument<DataTable>(), "datatable") : (OutArgument<DataTable>)Argument.CreateReference((Argument)this.datatable, "datatable")), args = (this.args == null ? (OutArgument<string>)Argument.CreateReference((Argument)new OutArgument<string>(), "args") : (OutArgument<string>)Argument.CreateReference((Argument)this.args, "args")), };
            };
        }
    }

    internal class YahooFinance_GetHistoricalAsyncActivityChild : CodeActivity
    {
        public InArgument<string> ticket { get; set; }

        public OutArgument<DataTable> datatable { get; set; }

        public OutArgument<string> args { get; set; }

        public YahooFinance_GetHistoricalAsyncActivityChild()
        {
            DisplayName = "YahooFinance_GetHistoricalAsync";
        }

        protected override void Execute(CodeActivityContext context)
        {
            var codedWorkflow = new global::finanaceCSharp.YahooFinance_GetHistoricalAsync();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            var result = CodedWorkflowHelper.RunWithExceptionHandling(() =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.Before(new BeforeRunContext()
                    {RelativeFilePath = "YahooFinance_GetHistoricalAsync.cs"});
                }
            }, () =>
            {
                var result = codedWorkflow.Execute(ticket.Get(context));
                var newResult = new System.Collections.Generic.Dictionary<string, object>{{"datatable", result.datatable}, {"args", result.args}, };
                return newResult;
            }, (exception, outArgs) =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.After(new AfterRunContext()
                    {RelativeFilePath = "YahooFinance_GetHistoricalAsync.cs", Exception = exception});
                }
            });
            datatable.Set(context, (DataTable)result["datatable"]);
            args.Set(context, (string)result["args"]);
        }
    }
}