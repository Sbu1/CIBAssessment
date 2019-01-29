using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

      //TODO proper message if there are no entries for a phonebook id

      return entries;
    }

    public List<Entry> getEntry(int phonebbookid, string name)
    {
      return _AssessmentContext.Entry.Where(x => x.Name.Contains(name) && x.PhonebookId == phonebbookid).ToList();
    }

    public Entry GetEntry(int entryId)
    {
      var entry = _AssessmentContext.Entry.FirstOrDefault(x => x.EntryId == entryId);
      return entry;
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

    public void UpdatEntry(int id, Entry entry)
    {
      var result = GetEntry(id);
      result.Name = entry.Name;
      result.PhoneNumber = entry.PhoneNumber;
      result.PhonebookId = entry.PhonebookId;
      _AssessmentContext.SaveChanges();
    }
  }
}
