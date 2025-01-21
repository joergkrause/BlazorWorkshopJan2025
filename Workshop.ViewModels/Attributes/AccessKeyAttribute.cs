using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.ViewModels.Attributes
{
  [AttributeUsage(AttributeTargets.Property)]
  public class AccessKeyAttribute : Attribute
  {
    public char Key { get; set; }

    public AccessKeyAttribute(char key)
    {
      Key = key;
    }
  }
}
