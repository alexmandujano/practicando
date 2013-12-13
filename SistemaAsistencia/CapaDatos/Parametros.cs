using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class Parametros
    {
        private String m_Nombre;
        private Object m_Valor;
        private SqlDbType m_TipoDato;
        private ParameterDirection m_direccion;
        private int m_Tamaño;
        


        public String Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }
       

        public Object Valor
        {
            get { return m_Valor; }
            set { m_Valor = value; }
        }
        

        public SqlDbType TipoDato
        {
            get { return m_TipoDato; }
            set { m_TipoDato = value; }
        }
       
        public ParameterDirection Direccion
        {
            get { return m_direccion; }
            set { m_direccion = value; }
        }
        

        public int Tamaño
        {
            get { return m_Tamaño; }
            set { m_Tamaño = value; }
        }

        public Parametros (String ObjNombre,Object ObjValor)
        {
            m_Nombre=ObjNombre;
            m_Valor=ObjValor;
            m_direccion=ParameterDirection.Input;
        }

        public Parametros(String ObjNombre, Object ObjValor, SqlDbType objTipoDato, ParameterDirection ObjDireccion, int ObjTamaño)
        {
            m_Nombre = ObjNombre;
            m_Valor = ObjValor;
            m_TipoDato = objTipoDato;
            m_direccion = ObjDireccion;
            m_Tamaño = ObjTamaño;
        
        }

        

    }
}
