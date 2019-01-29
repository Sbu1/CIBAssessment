using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CIBAssessment.API.Middleware;
using CIBAssessment.Common.Interface;
using CIBAssessment.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CIBAssessment.API.Controllers
{
  [Route("api/[controller]")]
  public class EntryController : Controller
  {
    private readonly IEntryService _entryService;

    public EntryController(IEntryService entryService)
    {
      _entryService = entryService;
    }

    [HttpGet("{id}")]
    public ActionResult<List<Entry>> Get(int phonebookId, [FromQuery] string name)
    {
      return !string.IsNullOrEmpty(name) ? _entryService.GetEntries(phonebookId, name) : _entryService.GetEntries(phonebookId);
    }

    // POST api/<controller>
    [HttpPost]
    public ActionResult<Entry> Post([FromBody]Entry entry)
    {
      return _entryService.AddEntry(entry);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody]Entry entry)
    {
       _entryService.UpdateEntry(id, entry);
       return Ok();
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      _entryService.DeleteEntry(id);
      return NoContent();
    }
  }
}
