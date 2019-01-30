using System;
using System.Collections.Generic;
using System.Text;
using CIBAssessment.Data.Models;
using CIBAssessment.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CIBAssessment.Tests
{
  [TestFixture]
  public class EntryServiceTests : ServiceBase
  {
    private EntryService _entryService;
    [SetUp]
    public void SetUp()
    {
      var options = new DbContextOptionsBuilder<CBIAssessmentContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      CbiAssessmentContext = new CBIAssessmentContext(options);
     // addPhonebookData();

      _entryService = new EntryService(CbiAssessmentContext);
    }

    
  }
}
