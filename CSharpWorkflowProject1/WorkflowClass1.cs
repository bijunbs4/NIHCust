using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace CSharpWorkflowProject1
{


    public class WorkflowClass1 : CodeActivity
    {

        [Input("Input")]
        [Default(null)]
        [RequiredArgument]
        public InArgument<String> InputArgument { get; set; }

        [Output("My Output")]
        public OutArgument<String> OutputArgument { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            ITracingService tracer = executionContext.GetExtension<ITracingService>();
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
                var myVariable = executionContext.GetValue(InputArgument);

                myVariable = $"{myVariable}: TEST";

                this.OutputArgument.Set(executionContext, myVariable);
                //TODO: Do stuff
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message);
            }
        }
    }
}