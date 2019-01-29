using System;
using System.Collections.Generic;
using System.Text;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CIBAssessment.Tests
{
  public abstract class ServiceBase
  {
    private DbContextOptions<CBIAssessmentContext> _options;
    protected CBIAssessmentContext Db;

    [SetUp]
    public void Setup()
    {
     var serviceProvider = new ServiceCollection()
       .AddEntityFrameworkInMemoryDatabase()
       .BuildServiceProvider();

     _options = new DbContextOptionsBuilder<CBIAssessmentContext>()
       .UseInMemoryDatabase(Guid.NewGuid().ToString())
       .UseInternalServiceProvider(serviceProvider)
       .Options;

     Db = new CBIAssessmentContext(_options);
     Db.Database.EnsureCreated();
     SetupData();
    }

    public void SetupData()
    {
      AddPhonebooks();
    }

    public IEnumerable<Phonebook> AddPhonebooks()
    {
      using (var db = new CBIAssessmentContext(_options))
      {
        var phonebook = new List<Phonebook>
        {
          new Phonebook
          {
            Name = "Private"
          },
          new Phonebook()
          {
            Name = "Public"
          }
        };

        db.Phonebook.AddRange(phonebook);
        db.SaveChanges();

        return phonebook;
      }
    }


  }
}
