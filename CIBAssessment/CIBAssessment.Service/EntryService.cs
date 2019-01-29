using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CIBAssessment.Common.Exceptions;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;

namespace CIBAssessment.Service
{
  public class EntryService : IEntryService
  {
    public readonly CBIAssessmentContext _AssessmentContext;

    public EntryService(CBIAssessmentContext cbiAssessmentContext)
    {
      _AssessmentContext = cbiAssessmentContext;
    }
    public List<Entry> GetEntries(int phonebookId)
    {
      var entries = _AssessmentContext.Entry.Where(x => x.PhonebookId == phonebookId).ToList();
      return entries;
    }

    public List<Entry> GetEntries(int phonebookid, string name)
    {
      return _AssessmentContext.Entry.Where(x => x.Name.StartsWith(name) && x.PhonebookId == phonebookid).ToList();
    }

    public Entry AddEntry(Entry entry)
    {
      _AssessmentContext.Add(entry);
      _AssessmentContext.SaveChanges();

      return entry;
    }

    public void DeleteEntry(int id)
    {
      var entry = GetEntry(id);

      _AssessmentContext.Entry.Remove(entry);
      _AssessmentContext.SaveChanges();
    }

    public void UpdateEntry(int id, Entry entry)
    {
      var result = GetEntry(id);
      result.Name = entry.Name;
      result.PhoneNumber = entry.PhoneNumber;
      result.PhonebookId = entry.PhonebookId;
      _AssessmentContext.SaveChanges();
    }

    private Entry GetEntry(int entryId)
    {
      var result = _AssessmentContext.Entry.First(x => x.EntryId == entryId);

      if (result is null)
        throw new HttpStatusCodeException(Convert.ToInt32(HttpStatusCode.BadRequest), "Invalid contact");

      return result;
    }
  }
}
