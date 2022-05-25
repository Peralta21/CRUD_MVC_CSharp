using CRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Datos
{
    public class CategoriaDatos
    {
        public List<CategoriaModel> Listar()
        {
            var lista = new List<CategoriaModel>();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Usp_List_Categorias", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CategoriaModel()
                        {
                            nIdCategori = Convert.ToInt32(dr["nIdCategori"]),
                            cNombCateg = dr["cNombCateg"].ToString(),
                            cEsActiva = Convert.ToBoolean(dr["cEsActiva"])
                        });
                    }
                }
            }
            return lista;
        }

        public CategoriaModel Obtener(int idCategoria)
        {
            var categoria = new CategoriaModel();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Usp_Get_Categoria", connection);
                cmd.Parameters.AddWithValue("IDCATEGORIA", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        categoria.nIdCategori = Convert.ToInt32(dr["nIdCategori"]);
                        categoria.cNombCateg = dr["cNombCateg"].ToString();
                        categoria.cEsActiva = Convert.ToBoolean(dr["cEsActiva"]);
                    }
                }
            }
            return categoria;
        }

        public bool Insertar(CategoriaModel categoria)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Ins_Co_Categoria", connection);
                    cmd.Parameters.AddWithValue("IDCATEGORIA", categoria.nIdCategori);
                    cmd.Parameters.AddWithValue("NOMBCATEGORIA", categoria.cNombCateg);
                    cmd.Parameters.AddWithValue("ESTADO", categoria.cEsActiva);
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

        public bool Actualizar(CategoriaModel categoria)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Update_Categoria", connection);
                    cmd.Parameters.AddWithValue("IDCATEGORIA", categoria.nIdCategori);
                    cmd.Parameters.AddWithValue("NOMBCATEGORIA", categoria.cNombCateg);
                    cmd.Parameters.AddWithValue("ESTADO", categoria.cEsActiva);
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

        public bool Delete(int IdCategoria)
        {
            bool respt;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Delete_Categoria", connection);
                    cmd.Parameters.AddWithValue("IDCATEGORIA", IdCategoria);
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
