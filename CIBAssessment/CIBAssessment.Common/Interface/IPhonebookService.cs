using System;
using System.Collections.Generic;
using System.Text;
using CIBAssessment.Data.Models;

namespace CIBAssessment.Common.Interface
{
  public interface IPhonebookService
  {
    List<Phonebook> GetPhonebooks();
    Phonebook GetPhonebook(int id);
    Phonebook AddPhonebook(Phonebook phonebook);

    void UpdatePhonebook(int id, Phonebook phonebook);

    void DeletePhonebook(int id);
  }
}
