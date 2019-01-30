using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Http;
using CIBAssessment.Common.Exceptions;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using CIBAssessment.Service;
using CIBAssessment.Tests;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NSubstitute;

namespace Tests
{
  [TestFixture]
  public class Tests
  {
    private CBIAssessmentContext _cbiAssessmentContext;
    private PhonebookSevice _phonebookSevice;
    [SetUp]
    public void SetUp()
    {
      var options = new DbContextOptionsBuilder<CBIAssessmentContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      _cbiAssessmentContext = new CBIAssessmentContext(options);
      addPhonebookData();

      _phonebookSevice = new PhonebookSevice(_cbiAssessmentContext);
    }

    [Test]
    public void GetPhonebook_GivenValidPhonebookID_ShouldReturnPhonebook()
    {
      var phonebookid = 1;
      var result = _phonebookSevice.GetPhonebook(phonebookid);
      Assert.IsNotNull(result);
    }

    [Test]
    public void GetPhonebook_GivenInValidPhonebookID_ShouldThrowException()
    {
      var phonebookid = -1;

      Assert.Throws<HttpStatusCodeException>(() => _phonebookSevice.GetPhonebook(phonebookid));
    }
    [Test]
    public void AddPhonebook_GivenValidPhonebook_ShouldAddPhonebook()
    {
      var before = _phonebookSevice.GetPhonebooks();
      _phonebookSevice.AddPhonebook(new Phonebook() {Name = "Unit Test"});
      var after = _phonebookSevice.GetPhonebooks();
      Assert.Greater(after.Count, before.Count);
    }
    //TODO more tests for addPhonebook

    

    public void addPhonebookData()
    {
      _cbiAssessmentContext.Phonebook.Add(new Phonebook(){Name = "TestData"});
      _cbiAssessmentContext.Phonebook.Add(new Phonebook() { Name = "TestData2" });
      _cbiAssessmentContext.SaveChanges();
    }
  }
}