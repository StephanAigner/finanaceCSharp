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
using finanaceCSharp.helper;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace finanaceCSharp
{
    public class InitDataTable : CodedWorkflow
    {
        [Workflow]
        public void Execute(string ticket,DataTable datatable)
        {
            //datatable.TableName = tabName;
            
            DataColumn idColumn = new DataColumn("id");
            idColumn.AutoIncrement= true;
            idColumn.DataType = typeof(System.Guid);
            datatable.Columns.Add(idColumn);
            
            DataColumn ticketColumn = new DataColumn("ticket");
            ticketColumn.DataType = typeof(System.String);
            ticketColumn.MaxLength=56;
            datatable.Columns.Add(ticketColumn);
            
            datatable.Rows.OfType<DataRow>().ToList<DataRow>().ForEach( x => {
                x.BeginEdit();
                x["id"]= Guid.NewGuid();
                x["ticket"]= ticket;
                x.EndEdit();
            });
            
            datatable.PrimaryKey = new DataColumn[1]{idColumn};
            //string sql_tab = SQL_Helper.GetCreateTableSql(datatable);
            
            //Console.WriteLine(string.Join(Environment.NewLine, datatable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray))));
            //Console.WriteLine(string.Join(Environment.NewLine, datatable.Columns.OfType<DataColumn>().Select(x => string.Join(" ; ", x.DataType))));
        }
    }
}