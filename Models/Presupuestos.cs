namespace tl2_tp7_2025_NievaS24.Models;

public class Presupuestos
{
    public int idPresupuesto {get; set;}
    public string nombreDestinatario {get; set;}
    public DateTime FechaCreacion {get; set;}
    public List<PresupuestosDetalle> detalles {get; set;}

    public double MontoPresupuesto ()
    {
        double total = 0;
        foreach (var detalle in detalles)
        {
            total += detalle.producto.precio * detalle.cantidad;
        }
        return total;
    }

    public double MontoPresupuestoConIva()
    {
        return MontoPresupuesto() * 1.21;
    }
}