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
    public class InitTableActivity : System.Activities.Activity
    {
        public InArgument<string> ticket { get; set; }

        public InArgument<DataTable> datatable { get; set; }

        public InArgument<UiPath.Database.DatabaseConnection> con { get; set; }

        public InitTableActivity()
        {
            this.Implementation = () =>
            {
                return new InitTableActivityChild()
                {ticket = (this.ticket == null ? (InArgument<string>)Argument.CreateReference((Argument)new InArgument<string>(), "ticket") : (InArgument<string>)Argument.CreateReference((Argument)this.ticket, "ticket")), datatable = (this.datatable == null ? (InArgument<DataTable>)Argument.CreateReference((Argument)new InArgument<DataTable>(), "datatable") : (InArgument<DataTable>)Argument.CreateReference((Argument)this.datatable, "datatable")), con = (this.con == null ? (InArgument<UiPath.Database.DatabaseConnection>)Argument.CreateReference((Argument)new InArgument<UiPath.Database.DatabaseConnection>(), "con") : (InArgument<UiPath.Database.DatabaseConnection>)Argument.CreateReference((Argument)this.con, "con")), };
            };
        }
    }

    internal class InitTableActivityChild : CodeActivity
    {
        public InArgument<string> ticket { get; set; }

        public InArgument<DataTable> datatable { get; set; }

        public InArgument<UiPath.Database.DatabaseConnection> con { get; set; }

        public InitTableActivityChild()
        {
            DisplayName = "InitTable";
        }

        protected override void Execute(CodeActivityContext context)
        {
            var codedWorkflow = new global::finanaceCSharp.InitTable();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            CodedWorkflowHelper.RunWithExceptionHandling(() =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.Before(new BeforeRunContext()
                    {RelativeFilePath = "InitTable.cs"});
                }
            }, () =>
            {
                codedWorkflow.Execute(ticket.Get(context), datatable.Get(context), con.Get(context));
                return null;
            }, (exception, outArgs) =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.After(new AfterRunContext()
                    {RelativeFilePath = "InitTable.cs", Exception = exception});
                }
            });
        }
    }
}