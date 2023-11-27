using System.Activities;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Utils;
using finanaceCSharp.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;
using finanaceCSharp.helper;
using System.Linq;
using System.ComponentModel;

namespace finanaceCSharp
{
    public class InitDataTableActivity : System.Activities.Activity
    {
        public InArgument<string> ticket { get; set; }

        public InArgument<DataTable> datatable { get; set; }

        public InitDataTableActivity()
        {
            this.Implementation = () =>
            {
                return new InitDataTableActivityChild()
                {ticket = (this.ticket == null ? (InArgument<string>)Argument.CreateReference((Argument)new InArgument<string>(), "ticket") : (InArgument<string>)Argument.CreateReference((Argument)this.ticket, "ticket")), datatable = (this.datatable == null ? (InArgument<DataTable>)Argument.CreateReference((Argument)new InArgument<DataTable>(), "datatable") : (InArgument<DataTable>)Argument.CreateReference((Argument)this.datatable, "datatable")), };
            };
        }
    }

    internal class InitDataTableActivityChild : CodeActivity
    {
        public InArgument<string> ticket { get; set; }

        public InArgument<DataTable> datatable { get; set; }

        public InitDataTableActivityChild()
        {
            DisplayName = "InitDataTable";
        }

        protected override void Execute(CodeActivityContext context)
        {
            var codedWorkflow = new global::finanaceCSharp.InitDataTable();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            CodedWorkflowHelper.RunWithExceptionHandling(() =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.Before(new BeforeRunContext()
                    {RelativeFilePath = "InitDataTable.cs"});
                }
            }, () =>
            {
                codedWorkflow.Execute(ticket.Get(context), datatable.Get(context));
                return null;
            }, (exception, outArgs) =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.After(new AfterRunContext()
                    {RelativeFilePath = "InitDataTable.cs", Exception = exception});
                }
            });
        }
    }
}