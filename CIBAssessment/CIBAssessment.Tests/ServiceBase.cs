using System;
using System.Collections.Generic;
using System.Text;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using CIBAssessment.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CIBAssessment.Tests
{
  public abstract class ServiceBase
  {
    protected CBIAssessmentContext _cbiAssessmentContext;

    [SetUp]
    public void SetUp()
    {

      var options = new DbContextOptionsBuilder<CBIAssessmentContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      _cbiAssessmentContext = new CBIAssessmentContext(options);
      addPhonebookData();
    }
    private void addPhonebookData()
    {
      _cbiAssessmentContext.Phonebook.Add(new Phonebook() { Name = "TestData", PhonebookId = 1 });
      _cbiAssessmentContext.Phonebook.Add(new Phonebook() { Name = "TestData2", PhonebookId = 2 });
      _cbiAssessmentContext.SaveChanges();
    }

  }
}
