using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace project8_sqlserver_plantillasenlasvistas.Models
{
    public class MantenimientoArticulo
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }


        public int Alta(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into articulos(codigo,description,precio) values (@codigo,@description,@precio)", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters.Add("@description", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@codigo"].Value = art.codigo;
            comando.Parameters["@description"].Value = art.description;
            comando.Parameters["@precio"].Value = art.precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Articulo> RecuperarTodos()
        {
            Conectar();
            List<Articulo> articulos = new List<Articulo>();

            SqlCommand com = new SqlCommand("select codigo,description,precio from articulos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Articulo art = new Articulo
                {
                    codigo = int.Parse(registros["codigo"].ToString()),
                    description = registros["description"].ToString(),
                    precio = registros["precio"].ToString()
                };
                articulos.Add(art);
            }
            con.Close();
            return articulos;
        }

        public Articulo Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select codigo,description,precio from articulos where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Articulo articulo = new Articulo();
            if (registros.Read())
            {
                articulo.codigo = int.Parse(registros["codigo"].ToString());
                articulo.description = registros["description"].ToString();
                articulo.precio = registros["precio"].ToString();
            }
            con.Close();
            return articulo;
        }


        public int Modificar(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update articulos set description=@description,precio=@precio where codigo=@codigo", con);
            comando.Parameters.Add("@description", SqlDbType.VarChar);
            comando.Parameters["@description"].Value = art.description;
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@precio"].Value = art.precio;
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = art.codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from articulos where codigo=@codigo", con);
            comando.Parameters.Add("@codigo", SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }




    }
}