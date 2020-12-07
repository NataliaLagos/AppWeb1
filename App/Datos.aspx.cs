using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleados.App
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        //crear objeto para gestionar datos
        GestionDatos datos = new GestionDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //En una lista invocamos  el objeto para listar todos los empleados
                List<Empleados> listaEmpleados = datos.LeerTodos();
                //Volcamos la de nuestro  gv
                gvEmpleados.DataSource = listaEmpleados;
                gvEmpleados.DataBind();
            }
        }

        protected void btnListarTodo_Click(object sender, EventArgs e)
        {
            //invocamos el objetopara listar empleados
            List<Empleados> ListaEmpleados = datos.LeerTodos();
            //Volcamos la lista a nuestro grview
            gvEmpleados.DataSource = ListaEmpleados;
            gvEmpleados.DataBind();

        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            List<Empleados> ListaEmpleados = datos.LeerTodos();
            gvEmpleados.DataSource = ListaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void BtnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (datos.ExisteEmpleado(inCodigoBuscar.Text))
            {
                Response.Redirect("Formulario.aspx?id=" + inCodigoBuscar.Text);
            }
            else {
                LabelBuscar.Text = " No existe elcodigo en la base de datos";
            }
        }
        protected void Seleccionar(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(gvEmpleados.DataKeys[indice].Value);
                //Response.Write("Valor de fila " + indice);
                //Response.Write("Valor celda " + valor);
                Response.Redirect("Formulario.aspx?id=" + valor);
            }
        }
    }
}