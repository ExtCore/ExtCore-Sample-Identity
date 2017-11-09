// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.Abstractions;
using Extension.Data.Abstractions;
using Extension.Data.Entities;
using Extension.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Extension.Controllers
{
  public class DefaultController : Controller
  {
    private IStorage storage;
    private UserManager<ApplicationUser> userManager;

    public DefaultController(IStorage storage, UserManager<ApplicationUser> userManager)
    {
      this.storage = storage;
      this.userManager = userManager;
    }

    public ActionResult Index()
    {
      //ApplicationUser applicationUser = new ApplicationUser();

      //applicationUser.UserName = "Administrator";

      //IdentityResult result = userManager.CreateAsync(applicationUser).Result;

      return this.View(
        new IndexViewModel()
        {
          Persons = this.storage.GetRepository<IPersonRepository>().All(),
          Users = this.userManager.Users
        }
      );
    }
  }
}