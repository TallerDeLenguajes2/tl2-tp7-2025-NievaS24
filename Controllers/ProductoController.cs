using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_NievaS24.Models;
using tl2_tp7_2025_NievaS24.Repository;

namespace tl2_tp7_2025_NievaS24.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository productoRepository;
    public ProductoController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpPost("Productos/Crear")]
    public IActionResult crearProducto([FromBody] Productos productoNuevo)
    {
        productoRepository.Create(productoNuevo);
        return Created($"/Productos/{productoNuevo.idProducto}", productoNuevo);
    }

    [HttpPut("Productos/Modificar")]
    public IActionResult modificarProducto(int idProd, [FromBody] Productos productoModificado)
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
}