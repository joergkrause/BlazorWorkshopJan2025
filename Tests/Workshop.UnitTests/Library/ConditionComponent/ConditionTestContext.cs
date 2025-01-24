using AngleSharp.Html.Dom;
using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Library;

namespace Workshop.UnitTests.Library.ConditionComponent
{
  [TestClass]
  [TestCategory("Condition")]
  public class ConditionTestContext : ConditionContext
  {

    [TestMethod]
    public void Condition_CheckTrueShouldRenderIf()
    {
      // Arrange
      var cut = RenderComponent<Condition>();
      // Act
      cut.SetParametersAndRender(parameters => parameters
        .Add(p => p.Check, true)
        .Add(p => p.If, "<div>IF</div>")
      );
      // Assert
      cut.MarkupMatches("<div>IF</div>");

    }

    [TestMethod]
    public void Condition_CheckFalseShouldRenderElse()
    {
      // Arrange
      var cut = RenderComponent<Condition>();

      // Act
      cut.SetParametersAndRender(parameters => parameters
        .Add(p => p.Check, false)
        .Add(p => p.If, "<div>IF</div>")
        .Add(p => p.Else, "<div>ELSE</div>")
      );

      // Assert
      // variant 1
      // cut.MarkupMatches("<div>ELSE</div>");

      // variant 2
      
      Assert.AreEqual("<div>ELSE</div>", ((IHtmlElement)cut.Nodes.First()).InnerHtml);
    }


  }
}
