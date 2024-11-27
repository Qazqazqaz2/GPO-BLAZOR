using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace GPO_BLAZOR.Client.Class.Field;

public partial class TymeField : Field
{
    private DateTime DateTime
    {
        get
        {
            return System.DateTime.Parse(Date.value);
        }
        set
        {
            Date.value = value.ToString();
        }
    }

    protected override void OnParametersSet()
    {
        if (Date.value=="" || Date.value==" ")
        {
            Date.value = DateTime.Now.ToString();
        }

        base.OnParametersSet();
    }
}