using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_NievaS24.Models;
using tl2_tp7_2025_NievaS24.Repository;

namespace tl2_tp7_2025_NievaS24.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestosRepository presupuestosRepository;
    public PresupuestoController()
    {
        presupuestosRepository = new PresupuestosRepository();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Presupuestos presupuestoNuevo)
    {
        presupuestosRepository.Create(presupuestoNuevo);
        return Created($"/Presupuestos/{presupuestoNuevo.idPresupuesto}", presupuestoNuevo);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(presupuestosRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(presupuestosRepository.GetById(id));
        }
        catch (KeyNotFoundException e)
        {

            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        try
        {
            presupuestosRepository.Delete(id);
            return Ok($"El presupuesto {id} se elimino correctamente.");
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}