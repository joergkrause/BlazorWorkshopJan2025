﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.UnitTests.Library.ProductsComponent
{
  public abstract class ProductsTest : BunitTestContext
  {

    [TestInitialize]
    public override void Setup()
    {
      base.Setup();
    }

    [TestCleanup]
    public override void Teardown()
    {
      base.Teardown();
    }

    protected override Bunit.TestContext Init()
    {
      return base.Init();

    }
  }
}
