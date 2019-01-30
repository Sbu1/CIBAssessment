using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    protected CBIAssessmentContext CbiAssessmentContext;

    [SetUp]
    public async Task SetUp()
    {

      var options = new DbContextOptionsBuilder<CBIAssessmentContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      CbiAssessmentContext = new CBIAssessmentContext(options);
      await addPhonebookData();
    }

    private async Task addPhonebookData()
    {
      var phonebook = new List<Phonebook>
      {
        new Phonebook() {Name = "TestData", PhonebookId = 1},
        new Phonebook() {Name = "TestData2", PhonebookId = 2}
      };

      await CbiAssessmentContext.Phonebook.AddRangeAsync(phonebook);
      await CbiAssessmentContext.SaveChangesAsync();

      var entries = new List<Entry>
      {
        new Entry {EntryId = 1, Name = "Black Coffee", PhoneNumber = 0711234567, PhonebookId = 1},
        new Entry {EntryId = 2, Name = "Sibusiso Sikhakhane", PhoneNumber = 0711111111, PhonebookId = 1},
        new Entry {EntryId = 3, Name = "Sethu Mazibuko", PhoneNumber = 0311111111, PhonebookId = 2},
        new Entry {EntryId = 4, Name = "Anita Zulu", PhoneNumber = 0111341111, PhonebookId = 2}
      };

      await CbiAssessmentContext.Entry.AddRangeAsync(entries);
      await CbiAssessmentContext.SaveChangesAsync();
    }
  }
}
