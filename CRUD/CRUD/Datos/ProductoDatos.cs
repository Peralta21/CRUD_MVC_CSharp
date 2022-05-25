using CRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> Listar()
        {
            var lista = new List<ProductoModel>();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Usp_List_Productos", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ProductoModel()
                        {
                            nIdProduct = Convert.ToInt32(dr["nIdProduct"]),
                            cNombProdu = dr["cNombProdu"].ToString(),
                            nPrecioProd = Convert.ToInt32(dr["nPrecioProd"]),
                            cNombCateg = dr["cNombCateg"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public List<ProductoModel> Listar(int idCategoria)
        {
            var lista = new List<ProductoModel>();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Usp_Sel_Co_Productos", connection);
                cmd.Parameters.AddWithValue("IDCATEGORIA", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ProductoModel()
                        {
                            nIdProduct = Convert.ToInt32(dr["nIdProduct"]),
                            cNombProdu = dr["cNombProdu"].ToString(),
                            nPrecioProd = Convert.ToInt32(dr["nPrecioProd"]),
                            cNombCateg = dr["cNombCateg"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public ProductoModel Obtener(int idProducto)
        {
            var producto = new ProductoModel();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Usp_Get_Producto", connection);
                cmd.Parameters.AddWithValue("IDPRODUCTO", idProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        producto.nIdProduct = Convert.ToInt32(dr["nIdProduct"]);
                        producto.cNombProdu = dr["cNombProdu"].ToString();
                        producto.nPrecioProd = Convert.ToInt32(dr["nPrecioProd"]);
                        producto.nIdCategori = Convert.ToInt32(dr["nIdCategori"]);
                    }
                }
            }
            return producto;
        }

        public bool Insertar(ProductoModel producto)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Insert_Producto", connection);
                    cmd.Parameters.AddWithValue("IDPRODUCTO", producto.nIdProduct);
                    cmd.Parameters.AddWithValue("NOMBPRODUCTO", producto.cNombProdu);
                    cmd.Parameters.AddWithValue("PRECIOPRODUCTO", producto.nPrecioProd);
                    cmd.Parameters.AddWithValue("IDCATEGORIA", producto.nIdCategori);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respt = false;
            }
            return respt;
        }

        public bool Actualizar(ProductoModel producto)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Update_Producto", connection);
                    cmd.Parameters.AddWithValue("IDPRODUCTO", producto.nIdProduct);
                    cmd.Parameters.AddWithValue("NOMBPRODUCTO", producto.cNombProdu);
                    cmd.Parameters.AddWithValue("PRECIOPRODUCTO", producto.nPrecioProd);
                    cmd.Parameters.AddWithValue("IDCATEGORIA", producto.nIdCategori);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respt = false;
            }
            return respt;
        }

        public bool Delete(int IdProducto)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Delete_Producto", connection);
                    cmd.Parameters.AddWithValue("IDPRODUCTO", IdProducto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respt = false;
            }
            return respt;
        }
    }
}
