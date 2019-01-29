using System.Net;
using System.Web.Http;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using CIBAssessment.Service;
using CIBAssessment.Tests;
using NUnit.Framework;
using NSubstitute;

namespace Tests
{
  [TestFixture]
  public class Tests : ServiceBase
  {
    private IPhonebookService _PhonebookService;
    [SetUp]
    public void Setup(IPhonebookService phonebookService)
    {
      _PhonebookService = new PhonebookSevice(Db);
    }

    [Test]
    public void GetPhonebook_GivenValidPhonebook_ShouldAddPhonebook()
    {
      var phonebook = new Phonebook {Name = "Family"};

      var result = _PhonebookService.AddPhonebook(phonebook);
      Assert.True(result.Name.Equals("Family"));
    }

    [Test]
    public void GetPhonebooks_GivenNoparameter_ShouldReturnPhonebooks()
    {
      var result =_PhonebookService.GetPhonebooks();

      Assert.Greater(1, result.Count);
    }

    [Test]
    public void GetPhonebook_GivenValidPhonebookId_ShouldReturnPhonebook()
    {
      var result = _PhonebookService.GetPhonebook(1);
      Assert.IsNotNull(result);
    }

    [Test]
    public void GetPhonebook_GivenInvalidPhoneId_ShouldThrowException()
    {
      Assert.AreEqual(HttpStatusCode.NotFound, _PhonebookService.GetPhonebook(-1));
    }
//add more tests for getphonebook, deletephonebook, updatephonebook
//add unit tests for Entryservice
  }
}