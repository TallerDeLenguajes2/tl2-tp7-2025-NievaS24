using tl2_tp7_2025_NievaS24.Models;
using Microsoft.Data.Sqlite;

namespace tl2_tp7_2025_NievaS24.Repository;

public class ProductoRepository
{
    private string cadenaConexion = "Data Source=Tienda.db";
    public void Create(Productos producto) {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "  INSERT INTO Productos (Descripcion, precio) VALUE (@Descripcion, @precio)";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.descripcion));
        comando.Parameters.Add(new SqliteParameter("@precio", producto.precio));
        comando.ExecuteNonQuery();
    }
}