using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_NievaS24.Models;
using tl2_tp7_2025_NievaS24.Repository;

namespace tl2_tp7_2025_NievaS24.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository productoRepository;
    public ProductoController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(productoRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(productoRepository.GetById(id));
        }
        catch (KeyNotFoundException e)
        {

            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Productos productoNuevo)
    {
        productoRepository.Create(productoNuevo);
        return Created($"/Productos/{productoNuevo.idProducto}", productoNuevo);
    }

    [HttpPut("{idProd}")]
    public IActionResult Update(int idProd, [FromBody] Productos productoModificado)
    {
        try
        {
            productoRepository.Update(idProd, productoModificado);
            return Ok(productoModificado);
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
            productoRepository.Delete(id);
            return Ok($"El producto {id} se elimino correctamente.");
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

}