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

namespace finanaceCSharp.BusinessProcess
{
    public class CodedResetAssetValueActivity : System.Activities.Activity
    {
        public InArgument<string> assetName { get; set; }

        public OutArgument<bool> assetValueWasChanged { get; set; }

        public InOutArgument<string> assetValue { get; set; }

        public CodedResetAssetValueActivity()
        {
            this.Implementation = () =>
            {
                return new CodedResetAssetValueActivityChild()
                {assetName = (this.assetName == null ? (InArgument<string>)Argument.CreateReference((Argument)new InArgument<string>(), "assetName") : (InArgument<string>)Argument.CreateReference((Argument)this.assetName, "assetName")), assetValueWasChanged = (this.assetValueWasChanged == null ? (OutArgument<bool>)Argument.CreateReference((Argument)new OutArgument<bool>(), "assetValueWasChanged") : (OutArgument<bool>)Argument.CreateReference((Argument)this.assetValueWasChanged, "assetValueWasChanged")), assetValue = (this.assetValue == null ? (InOutArgument<string>)Argument.CreateReference((Argument)new InOutArgument<string>(), "assetValue") : (InOutArgument<string>)Argument.CreateReference((Argument)this.assetValue, "assetValue")), };
            };
        }
    }

    internal class CodedResetAssetValueActivityChild : CodeActivity
    {
        public InArgument<string> assetName { get; set; }

        public OutArgument<bool> assetValueWasChanged { get; set; }

        public InOutArgument<string> assetValue { get; set; }

        public CodedResetAssetValueActivityChild()
        {
            DisplayName = "CodedResetAssetValue";
        }

        protected override void Execute(CodeActivityContext context)
        {
            var codedWorkflow = new global::finanaceCSharp.BusinessProcess.CodedResetAssetValue();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            var result = CodedWorkflowHelper.RunWithExceptionHandling(() =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.Before(new BeforeRunContext()
                    {RelativeFilePath = "BusinessProcess\\CodedResetAssetValue.cs"});
                }
            }, () =>
            {
                var result = codedWorkflow.Execute(assetName.Get(context), assetValue.Get(context));
                var newResult = new System.Collections.Generic.Dictionary<string, object>{{"assetValueWasChanged", result.assetValueWasChanged}, {"assetValue", result.assetValue}, };
                return newResult;
            }, (exception, outArgs) =>
            {
                if (codedWorkflow is IBeforeAfterRun codedWorkflowWithBeforeAfter)
                {
                    codedWorkflowWithBeforeAfter.After(new AfterRunContext()
                    {RelativeFilePath = "BusinessProcess\\CodedResetAssetValue.cs", Exception = exception});
                }
            });
            assetValueWasChanged.Set(context, (bool)result["assetValueWasChanged"]);
            assetValue.Set(context, (string)result["assetValue"]);
        }
    }
}