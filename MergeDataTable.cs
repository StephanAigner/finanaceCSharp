using finanaceCSharp.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
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
    public class MergeDataTable : CodedWorkflow
    {
        [Workflow]
        public void Execute( DataTable datatable, DataTable datatable_main)
        {
            if (datatable_main==null && datatable==null) return;
            if (datatable == null) return;
            if (datatable_main==null) {
                datatable_main = new DataTable();
                datatable_main.TableName="ticket";
            }
            
            datatable_main.Merge(datatable);
        }
    }
}