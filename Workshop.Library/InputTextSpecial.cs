using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Library
{
  public class InputTextSpecial : InputBase<string>
  {

    [Parameter]
    public bool IsInputGroup { get; set; }

    [Parameter, EditorRequired]
    public MarkupString LabelText { get; set; } = default!;

    [Parameter]
    public string Id { get; set; } = $"_{Guid.NewGuid()}";

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
      var seq = 1;
      builder.OpenElement(seq++, "div");
      builder.AddAttribute(seq++, "class", IsInputGroup ? "input-group" : "form-group");
      {
        builder.OpenElement(seq++, "label");
        {
          builder.AddAttribute(seq++, "for", Id);
          builder.AddContent(seq++, LabelText);
        }
        builder.CloseElement();
      }
      {
        builder.OpenElement(seq++, "input");
        {
          builder.AddAttribute(seq++, "id", Id);
          builder.AddAttribute(seq++, "class", "form-control");
          builder.AddAttribute(seq++, "type", "text");
          builder.AddAttribute(seq++, "value", BindConverter.FormatValue(CurrentValueAsString));
          builder.AddAttribute(seq++, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
          builder.AddAttribute(seq++, "oninput", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        }
        builder.CloseElement();
      }
      builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
      result = value ?? string.Empty;
      validationErrorMessage = null;
      return true;
    }

    //protected override void Dispose(bool disposing)
    //{
    //  base.Dispose(disposing);
    //}
  }
}
