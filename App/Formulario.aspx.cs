using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleados.App
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ValidarCajas Validar = new ValidarCajas();
        GestionDatos datos = new GestionDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cuando se carga el formulario 
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {

                    InCodigo.Text = Request.QueryString["id"];
                    Empleados myEmpleado = datos.consultaEmpleado(InCodigo.Text);

                    InApellido.Text = myEmpleado.Apellido;
                    InCargo.Text = myEmpleado.Cargo;
                    InArea.Text = myEmpleado.Area;
                    InNombre.Text = myEmpleado.Nombre;
                    InCiudad.Text = myEmpleado.Ciudad;
                    InSalario.Text = myEmpleado.Salario;
                    btnAgregarEmpleado.Visible = false;
                    btnEditarEmpleado.Visible = true;
                    btnBorrarEmpleado.Visible = true;
                    InCodigo.Enabled = false;
                }
                else {
                    InCodigo.Enabled = true;
                    btnAgregarEmpleado.Visible = true;
                    btnEditarEmpleado.Visible = false;
                    btnBorrarEmpleado.Visible = false;
                    return;
                }
            }
        }
     
        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            //Enviar datos
            if (!Validar.Vacio(InCodigo, ErrorCodigo, "No puede ser vacio"))
                if (!Validar.Vacio(InNombre, ErrorNombre, "No puede ser vacio"))
                    if (!Validar.Vacio(InApellido, ErrorApellido, "No puede ser vacio"))
                        if (!Validar.Vacio(InCargo, ErrorCargo, "No puede ser vacio"))
                            if (!Validar.Vacio(InSalario, ErrorSalario, "No puede ser vacio"))
                                if (!Validar.Vacio(InArea, ErrorArea, "No puede ser vacio"))
                                    if (!Validar.Vacio(InCiudad, ErrorCiudad, "No puede ser vacio"))
                                    { InsertarDatosBD(); }

        }
        

        //-------------------------------------------------
        //Insertar datos BD
        private void InsertarDatosBD()
        {
            Empleados myEmpleado = new Empleados();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;
            if (datos.InsertarEmpleadoBD(myEmpleado))
            {
                if (!datos.ExisteEmpleado(InCodigo.Text))

                {
                    LabelRta.Text = "El registro fue insertado satisfactoriamente";
                }
                else
                {
                    LabelRta.Text = "";
                }
            }
            else {
                LabelRta.Text = "El codigo " + InCodigo.Text +" ya existe";
            }

            LabelRta.Text = "Error al isnsertar"+datos.error;

        }
        private void LimpiarCampos()
        {
            InCodigo.Text = "";
            InApellido.Text = "";
            InCargo.Text = "";
            InArea.Text = "";
            InNombre.Text = "";
            InCiudad.Text = "";
            InSalario.Text = "";
        }

        protected void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            //Codigio para editar el emplado
            Empleados myEmpleado = new Empleados();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;

            if (datos.EditarEmpleadoBD(myEmpleado))
            {
                LabelRta.Text = " El registro fue actualizado correctamente";
            }
            else
            {
                LabelRta.Text = "Error al actualizar " + datos.error;
            }
        }

        protected void btnBorrarEmpleado_Click(object sender, EventArgs e)
        {
            //Codigo para eliminar el empleado

            if (datos.EliminarEmpleadoBD(InCodigo.Text))
            {
                LabelRta.Text = " El registro fue Borrado correctamente";
                LimpiarCampos();
            }
            else
            {
                LabelRta.Text = "Error al Borrar " + datos.error;
            }
        }
    }
}