using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Global.Components
{
    public class ConfirmComponentBase : ComponentBase
    {
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "This will delete the record. Still want to proceed?";

        [Parameter]
        public string ButtonText { get; set; } = "Delete";

        public bool showConfirmation { get; set; }
        public void show()
        {
            showConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged {get; set;}
        protected async Task OnConfirmationChange(bool value)
        {
            showConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
