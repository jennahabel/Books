// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Bookstore.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/_Imports.razor"
using Bookstore.Models;

#line default
#line hidden
#nullable disable
    public partial class PurchaseTable : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "/Users/jennaconnell/Documents/ISPROGRAM/IS413/Mission7/Books/Mission7/Pages/Admin/PurchaseTable.razor"
       

    [Parameter]
    public string TableTitle { get; set; } = "Purchases";

    [Parameter]
    public IEnumerable<Purchase> Purchases { get; set; }

    [Parameter]
    public string ButtonLabel { get; set; } = "Collected";

    [Parameter]
    public EventCallback<int> PurchaseSelected { get; set; }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
