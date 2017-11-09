// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using ExtCore.Data.EntityFramework;
using Extension.Data.Abstractions;
using Extension.Data.Entities;

namespace Extension.Data.EntityFramework.Sqlite
{
  public class PersonRepository : RepositoryBase<Person>, IPersonRepository
  {
    public IEnumerable<Person> All()
    {
      return this.dbSet.OrderBy(p => p.Name);
    }
  }
}