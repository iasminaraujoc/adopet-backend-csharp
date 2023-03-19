using alura_backend_csharp.Data;
using alura_backend_csharp.Data.Dtos;
using alura_backend_csharp.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace alura_backend_csharp.Controllers;

[ApiController]
[Route("[controller]")]
public class TutoresController : ControllerBase
{
    private TutorContext _context;
    private IMapper _mapper;

    public TutoresController(TutorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaTutor([FromBody] CreateTutorDto tutorDto)
    {
        Tutor tutor = _mapper.Map<Tutor>(tutorDto); 
        _context.Tutores.Add(tutor);
        _context.SaveChanges();
        var tutorCriado = _mapper.Map<ReadTutorDto>(tutor);
        return CreatedAtAction(nameof(RecuperaTutorPorId),
            new { id = tutor.Id },
            tutorCriado);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaTutorPorId(int id) 
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
        if (tutor == null) return NotFound();
        var tutorDto = _mapper.Map<ReadTutorDto>(tutor);
        return Ok(tutorDto);

    }

    [HttpGet]
    public IEnumerable<ReadTutorDto> RecuperaTutores([FromQuery] int skip = 0, [FromQuery] int take = 15) 
    {
        return _mapper.Map<List<ReadTutorDto>>(_context.Tutores.Skip(skip).Take(take));
    }

    [HttpPut]
    public IActionResult AtualizaTutor([FromBody] UpdateTutorDto tutorDto)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == tutorDto.Id);
        if (tutor == null) return NotFound();

        _mapper.Map(tutorDto, tutor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaTutorParcial(int id, JsonPatchDocument<UpdateTutorDto> patch)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
        if (tutor == null) return NotFound();

        var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);

        patch.ApplyTo(tutorParaAtualizar, ModelState);

        if (!TryValidateModel(tutorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(tutorParaAtualizar, tutor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaTutor(int id)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
        if (tutor == null) return NotFound();

        _context.Remove(tutor);
        _context.SaveChanges();
        return NoContent();
    }

}
