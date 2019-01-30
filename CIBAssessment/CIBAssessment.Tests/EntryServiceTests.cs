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
      _entryService = new EntryService(CbiAssessmentContext);
    }

    [Test]
    public void GetEntries_GivenValidPhonebookId_ShouldReturnEntries()
    {
      var result = _entryService.GetEntries(1);
      Assert.Greater(result.Count, 1);
    }

    [Test]
    public void GetEntries_GivenInValidPhonebookId_ShouldReturnEmptyEntries()
    {
      var result = _entryService.GetEntries(-1);
      Assert.IsEmpty(result);
    }

    [Test]
    public void GetEntries_GivenValidPhonebookIdAndName_ShouldReturnEntries()
    {
      var result = _entryService.GetEntries(1, "S");
      Assert.GreaterOrEqual(result.Count, 1);
    }

    [Test]
    public void GetEntries_GivenInvalidPhonebookIdAndCorrectName_ShouldReturnEmptyEntries()
    {
      var result = _entryService.GetEntries(-1, "S");
      Assert.IsEmpty(result);
    }

    [Test]
    public void GetEntries_GivenValidPhonebookIDAndIncorrectName_ShouldReturnEmptyEntries()
    {
      var result = _entryService.GetEntries(1, "ze");
      Assert.IsEmpty(result);
    }

  }
}
