using Microsoft.AspNetCore.Mvc;
using phonebook_cs.Models.Services;

namespace phonebook_cs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhoneBookController : ControllerBase
{
    private readonly PhoneBookService _service;

    public PhoneBookController(PhoneBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PhoneBookEntry>> GetAll([FromQuery] string? userInput)
    {
        return Ok(string.IsNullOrWhiteSpace(userInput)
            ? _service.GetAll()
            : _service.FilterByNameOrPrefix(userInput));
    }

    [HttpGet("{id}")]
    public ActionResult<PhoneBookEntry> GetById(long id)
    {
        var entry = _service.GetById(id);
        return entry == null ? NotFound() : Ok(entry);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PhoneBookEntry entry)
    {
        _service.Add(entry);
        return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] PhoneBookEntry entry)
    {
        return _service.Update(id, entry) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        return _service.Delete(id) ? NoContent() : NotFound();
    }
}
