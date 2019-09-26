using stackOverFlowApi.Models;
using Microsoft.AspNetCore.Mvc;
using stackoverflowapi;
using stackOverFlowApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace stackOverFlowApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnswersController : ControllerBase
  {
    private DatabaseContext context;

    public AnswersController(DatabaseContext _context)
    {
      this.context = _context;
    }


    [HttpPost]
    public ActionResult<Answers> CreateAnswers([FromBody]Answers entry)
    {
      context.Answers.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpPut("{id}")]

    public ActionResult<Answers> UpDateLike(int id, [FromBody] Answers Update)
    {
      if (id != Update.Id)
      {
        return BadRequest();
      }

      context.Entry(Update).State = EntityState.Modified; context.SaveChanges();
      return Update;
    }


  }
}
