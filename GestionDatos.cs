using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;

namespace AppEmpleados
{
    public class GestionDatos
    {
        public MySqlConnection conexion;
        public string error;
        public GestionDatos()
        {
            this.conexion = ConexionMysql.GetConexion();

        }
        public List<Empleados> LeerTodos()
        {
            List<Empleados> listaEmpleados = new List<Empleados>();
            string sql = "select * from empleados;";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader resultado = cmd.ExecuteReader();


            while (resultado.Read())
            {
                Empleados myEmpleados = new Empleados();
                myEmpleados.Codigo = resultado.GetString(1);
                myEmpleados.Nombre = resultado.GetString(2);
                myEmpleados.Apellido = resultado.GetString(3);
                myEmpleados.Cargo = resultado.GetString(4);
                myEmpleados.Salario = resultado.GetString(5);
                myEmpleados.Area = resultado.GetString(6);
                myEmpleados.Ciudad = resultado.GetString(7);
                listaEmpleados.Add(myEmpleados);
            }
            resultado.Close();
            return listaEmpleados;
        }

        public Boolean ExisteEmpleado(string codigo)
        {
            string sql = "select * from empleados where codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();
            if (resultado.Read())
            {
                resultado.Close();
                return true;
            }
            else
            {
                resultado.Close();
                return false;
            }

        }
        //Insertar uN objeto a la BD
        public Boolean InsertarEmpleadoBD(Empleados myEmpleado)
        {
            Boolean rta = false;
            try
            {
                string sql = "insert into  empleados(codigo, nombre, apellido, cargo,  salario, area, ciudad)values(@codigo, @nombre, @apellido, @cargo,  @salario, @area, @ciudad)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException excepcion)
            {

                this.error = excepcion.Message;

            }
            return rta;
        }
        //----------------------------------------------------------------------------
        //Insertar un objet a la base de datos
        public Empleados consultaEmpleado(string codigo)
        {
            string sql = "select * from empleados where codigo=@codigo;";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();
            if (resultado.Read())
            {
                Empleados myEmpleados = new Empleados();
                myEmpleados.Codigo = resultado.GetString(1);
                myEmpleados.Nombre = resultado.GetString(2);
                myEmpleados.Apellido = resultado.GetString(3);
                myEmpleados.Cargo = resultado.GetString(4);
                myEmpleados.Salario = resultado.GetString(5);
                myEmpleados.Area = resultado.GetString(6);
                myEmpleados.Ciudad = resultado.GetString(7);
                resultado.Close();
                return myEmpleados;
            }
            else
            {
                resultado.Close();
                return null;
            }

        }
        //Editar los datos de un empleado
        public Boolean EditarEmpleadoBD(Empleados myEmpleado)
        {
            Boolean rta = false;
            try
            {
                string sql = "update empleados set nombre= @nombre, apellido = @apellido, cargo = @cargo,  salario = @salario, area = @area, ciudad = @ciudad where codigo = @codigo)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException excepcion)
            {

                this.error = excepcion.Message;

            }
            return rta;
        }

        //Eliinar los datos de un empleado

        public Boolean EliminarEmpleadoBD(string codigo)
        {
            Boolean rta = false;
            try
            {
                string sql = "delete empleados where codigo = @codigo)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException excepcion)
            {

                this.error = excepcion.Message;

            }
            return rta;

        }
    }
}