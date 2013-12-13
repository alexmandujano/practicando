using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class Manejador
    {
        public SqlConnection conexion = new SqlConnection("server=SERVLINDA\\SQLEXPRESS;DataBase=AsistenciaBiometrico;Integrated Security=true");
        public void connectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public void desconectar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public DataTable Listado(String NombreSP, List<Parametros> lst)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                connectar();
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //verificamos si la lista no esta vacia
                if (lst != null)
                {
                    //recorremos la lista generica
                    for (int i = 0; i < lst.Count; i++)
                    {
                        //pasamos cada uno de los parametros
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            desconectar();
            //retornamos el data table
            return dt;

        }
        public void EjecutarSP(String Nombresp, ref List<Parametros> lst)
        {
            SqlCommand cmd;
            try
            {
                connectar();
                cmd = new SqlCommand(Nombresp, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //verificar si la lista no esta vacia
                if (lst != null)
                {
                    //recorremos lista
                    for (int i = 0; i < lst.Count; i++)
                    {
                        //verificamos si los parametros son de entrada
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);

                        }
                        //verificamos si los parametros son de salida
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output;

                        }

                    }

                    cmd.ExecuteNonQuery();
                    //Recuperamos los Datos de Salida

                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            lst[i].Valor = cmd.Parameters[i].Value;

                        }
                    }



                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



    }
}
