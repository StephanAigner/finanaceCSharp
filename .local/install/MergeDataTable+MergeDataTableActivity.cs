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
using System.Linq;

namespace finanaceCSharp
{
    public class MergeDataTableActivity : System.Activities.Activity
    {
        public InArgument<DataTable> datatable { get; set; }

        public InArgument<DataTable> datatable_main { get; set; }

        public MergeDataTableActivity()
        {
            this.Implementation = () =>
            {
                return new MergeDataTableActivityChild()
                {datatable = (this.datatable == null ? (InArgument<DataTable>)Argument.CreateReference((Argument)new InArgument<DataTable>(), "datatable") : (InArgument<DataTable>)Argument.CreateReference((Argument)this.datatable, "datatable")), datatable_main = (this.datatable_main == null ? (InArgument<DataTable>)Argument.CreateReference((Argument)new InArgument<DataTable>(), "datatable_main") : (InArgument<DataTable>)Argument.CreateReference((Argument)this.datatable_main, "datatable_main")), };
            };
        }
    }

    internal class MergeDataTableActivityChild : CodeActivity
    {
        public InArgument<DataTable> datatable { get; set; }

        public InArgument<DataTable> datatable_main { get; set; }

        public MergeDataTableActivityChild()
        {
            DisplayName = "MergeDataTable";
        }

        protected override void Execute(CodeActivityContext context)
        {
            var codedWorkflow = new global::finanaceCSharp.MergeDataTable();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            CodedWorkflowHelper.RunWithExceptionHandling(() =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.Before(new BeforeRunContext()
                    {RelativeFilePath = "MergeDataTable.cs"});
                }
            }, () =>
            {
                codedWorkflow.Execute(datatable.Get(context), datatable_main.Get(context));
                return null;
            }, (exception, outArgs) =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.After(new AfterRunContext()
                    {RelativeFilePath = "MergeDataTable.cs", Exception = exception});
                }
            });
        }
    }
}