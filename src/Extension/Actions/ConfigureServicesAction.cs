// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using ExtCore.Data.Abstractions;
using ExtCore.Infrastructure.Actions;
using Extension.Data.Entities;
using Extension.Data.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Extension.Actions
{
  public class ConfigureServicesAction : IConfigureServicesAction
  {
    public int Priority => 1000;

    public void Execute(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
    {
      // This is a bad (but quick) way to provide configurations to the extensions. A good one is to use the options pattern.
      IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(serviceProvider.GetService<IHostingEnvironment>().ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(configurationBuilder.Build().GetConnectionString("Default")));

      serviceCollection.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

      serviceCollection.AddScoped(typeof(IStorageContext), typeof(ApplicationDbContext));
    }
  }
}