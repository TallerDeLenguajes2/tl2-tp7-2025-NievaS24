using tl2_tp7_2025_NievaS24.Models;
using Microsoft.Data.Sqlite;

namespace tl2_tp7_2025_NievaS24.Repository;

public class ProductoRepository
{
    private string cadenaConexion = "Data Source=Tienda.db";
    public void Create(Productos producto)
    {
        using var con = new SqliteConnection(cadenaConexion);
        con.Open();
        string sql = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio); SELECT last_insert_rowid();";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
        cmd.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
        producto.idProducto = Convert.ToInt32(cmd.ExecuteScalar());
    }

    public void Update(int id, Productos producto)
    {

        using var con = new SqliteConnection(cadenaConexion);
        con.Open();
        string sql = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @Id";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
        cmd.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
        cmd.Parameters.Add(new SqliteParameter("@Id", id));
        int modificado = cmd.ExecuteNonQuery();
        producto.idProducto = id;
        if (modificado <= 0) throw new KeyNotFoundException($"El producto con id {id} no se encontro");
    }

}
