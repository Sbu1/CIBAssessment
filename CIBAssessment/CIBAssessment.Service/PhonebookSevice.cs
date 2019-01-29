using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Runtime.InteropServices;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Server;

namespace CIBAssessment.Service
{
  public class PhonebookSevice : IPhonebookService
  {
    public readonly CBIAssessmentContext _AssessmentContext;

    public PhonebookSevice(CBIAssessmentContext assessmentContext)
    {
      _AssessmentContext = assessmentContext;
    }

    public List<Phonebook> GetPhonebooks()
    {
      var phonebook = _AssessmentContext.Phonebook.ToList();
      return phonebook;
    }

    public Phonebook GetPhonebook(int id)
    {
      var phonebook = _AssessmentContext.Phonebook.FirstOrDefault(x => x.PhonebookId == id);
      if (phonebook is null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      return phonebook;
    }

    public Phonebook AddPhonebook(Phonebook phonebook)
    {
      _AssessmentContext.Add(phonebook);
      _AssessmentContext.SaveChanges();

      return phonebook;
    }

    public void UpdatePhonebook(int id, Phonebook phonebook)
    {
      var result = GetPhonebook(id);

      if (result is null)
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      result.Name = phonebook.Name;

      _AssessmentContext.SaveChanges();
    }

    public void DeletePhonebook(int id)
    {
      var result = GetPhonebook(id);

      if (result is null)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      _AssessmentContext.Remove(result);
      _AssessmentContext.SaveChanges();
    }
  }
}
