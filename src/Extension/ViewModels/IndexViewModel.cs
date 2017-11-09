// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Extension.Data.Entities;

namespace Extension.ViewModels
{
  public class IndexViewModel
  {
    public IEnumerable<Person> Persons { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
  }
}