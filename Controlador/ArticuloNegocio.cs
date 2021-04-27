﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
//using System.Windows.Forms;


namespace Controlador
{
    
    public class ArticuloNegocio
    {

        public List<Articulo> Listar()

        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "data source = .\\SQLEXPRESS; initial catalog = CATALOGO_DB;integrated security = sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion , C.Descripcion " +
                    "from ARTICULOS as A " +
                    "Inner Join Marcas as M on A.IdMarca = M.Id " +
                    "Inner Join CATEGORIAS as C on A.IdCategoria = C.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.nombre = lector.GetString(0);
                    aux.descripcion = lector.GetString(1);
                    aux.imagenUrl = lector.GetString(2);
                    aux.marca = lector.GetString(3);
                    aux.categoria = lector.GetString(4);

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;

            }
            catch (Exception ex2)
            {

                throw ex2;
            }



        }


    }
}