using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CIBAssessment.Controllers
{
  [Route("api/[controller]")]
  public class PhonebookController : Controller
  {
    private readonly IPhonebookService _phonebookService;

    public PhonebookController(IPhonebookService phonebookService)
    {
      _phonebookService = phonebookService;
    }
    // GET: api/<controller>
    [HttpGet]
    public ActionResult<List<Phonebook>> Get()
    {
      return _phonebookService.GetPhonebooks();
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public ActionResult<Phonebook> Get(int id)
    {
      return _phonebookService.GetPhonebook(id);
    }

    // POST api/<controller>
    [HttpPost]
    public ActionResult<Phonebook> Post([FromBody]Phonebook phonebook)
    {
      return _phonebookService.AddPhonebook(phonebook);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody]Phonebook phonebook)
    {
      _phonebookService.UpdatePhonebook(id, phonebook);
      return Ok();
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      _phonebookService.DeletePhonebook(id);
      return NoContent();
    }
  }
}
