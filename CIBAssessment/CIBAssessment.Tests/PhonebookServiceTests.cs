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
  public class PhonebookServiceTests : ServiceBase
  {
    private PhonebookSevice _phonebookSevice;
    //[SetUp]
    //public void SetUp()
    //{

    //  var options = new DbContextOptionsBuilder<CBIAssessmentContext>()
    //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
    //    .Options;
    //  _cbiAssessmentContext = new CBIAssessmentContext(options);
    //  addPhonebookData();

    //  _phonebookSevice = new PhonebookSevice(_cbiAssessmentContext);
    //}

    [SetUp]
    public void PhonebookSetup()
    {
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
      _phonebookSevice.AddPhonebook(new Phonebook() {PhonebookId = 3,Name = "Unit Test"});
      var after = _phonebookSevice.GetPhonebooks();
      Assert.Greater(after.Count, before.Count);
    }

    [Test]
    public void UpdatePhonebook_GivenValidPhonebook_ShouldUpdatePhonebook()
    {
      var phonebookid = 1;
      var phonebookName = "New Test Name";
      var phonebook = new Phonebook(){ Name = phonebookName};

      _phonebookSevice.UpdatePhonebook(phonebookid, phonebook);

      var result = _phonebookSevice.GetPhonebook(phonebookid);

      Assert.AreSame(phonebookName, result.Name );
    }

    [Test]
    public void DeletePhonebook_GivenValidPhonebookId_ShouldDeletePhonebook()
    {
      var phonebookid = 1;

      var before = _phonebookSevice.GetPhonebooks();
      _phonebookSevice.DeletePhonebook(phonebookid);
      var after = _phonebookSevice.GetPhonebooks();

      Assert.Less(after.Count, before.Count);
    }

    [Test]
    public void GetPhonebooks_ShouldReturnPhonebooks()
    {
      var result = _phonebookSevice.GetPhonebooks();

      Assert.IsNotNull(result);
    }

    private void addPhonebookData()
    {
      _cbiAssessmentContext.Phonebook.Add(new Phonebook(){Name = "TestData", PhonebookId = 1});
      _cbiAssessmentContext.Phonebook.Add(new Phonebook() { Name = "TestData2", PhonebookId = 2});
      _cbiAssessmentContext.SaveChanges();
    }
  }
}