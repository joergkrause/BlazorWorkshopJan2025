using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace Workshop.BlazorApp.Components.Pages
{
  public class PageBase<TState, TSelector> : FluxorComponent
  {

    [Inject]
    public IDispatcher Dispatcher { get; set; }

    [Inject]
    public IState<TState> State { get; set; }

    [Inject]
    public TSelector Selector { get; set; }

  }
}
