using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Workshop.ViewModels.Attributes;

namespace Workshop.Library
{
  public abstract class EditBase<TItem, TValue> : ComponentBase
  {
    protected string labelName;
    protected MarkupString labelText;
    protected char accessKey;
    protected int tabIndex;
    protected string description;
    protected string uihint;

    [Parameter, EditorRequired]
    public TItem Item { get; set; }

    [Parameter, EditorRequired]
    public Expression<Func<TValue>> For { get; set; }

    [Parameter]
    public TValue Value { get; set; }

    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    protected override void OnInitialized()
    {
      var memberExpression = (MemberExpression)For.Body;
      var property = (PropertyInfo)memberExpression.Member;
      labelName = property.Name;

      var accesskeyAttribute = property.GetCustomAttribute<AccessKeyAttribute>();
      if (accesskeyAttribute != null)
      {
        accessKey = accesskeyAttribute.Key;
      }

      var uihintAttribute = property.GetCustomAttribute<UIHintAttribute>();
      if (uihintAttribute != null)
      {
        uihint = uihintAttribute.UIHint;
      }

      var displayAttribute = property.GetCustomAttribute<DisplayAttribute>();
      if (displayAttribute != null)
      {
        labelText = GetStringWithHotkey(displayAttribute.Name ?? labelName, accessKey);
        description = displayAttribute.Description ?? "Keine Hilfe";
        tabIndex = displayAttribute.Order;
      }
      else
      {
        labelText = GetStringWithHotkey(labelName, accessKey);
      }

      MarkupString GetStringWithHotkey(string text, char hotkey)
      {
        var index = text.IndexOf(hotkey);
        if (index == -1)
        {
          return new MarkupString(text);
        }
        return new MarkupString($"{text.Substring(0, index)}<u>{hotkey}</u>{text.Substring(index + 1)}");
      }
    }
  }
}
