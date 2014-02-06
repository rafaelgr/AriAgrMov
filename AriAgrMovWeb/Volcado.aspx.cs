using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using AriAgrMovModelo;
using System.Linq;

public partial class Volcado : System.Web.UI.Page 
{
    #region Declaracion de variables
    AriAgrMod ctx;

    string mensError = @"
            <div class='panel panel-danger'>
                <div class='panel-heading'>
                    <h3 class='panel-title'>Error</h3>
                </div>
                <div class='panel-body'>
                    <p class='panel-content'>{0}</p>
                </div>
            </div>
    ";
    string mensOk = @"
            <div class='panel panel-success'>
                <div class='panel-heading'>
                    <h3 class='panel-title'>Palet volcado</h3>
                </div>
                <div class='panel-body'>
                    <div class='panel-content'>
                        <h5>Datos palet</h5>
                        <strong>RFID: </strong>{0} <strong>Código Palet:</strong>{1}<br />
                        <strong>Producto: </strong>{2} <strong>Variedad: </strong>{3} <br />
                        <h5>Datos volcado</h5>
                        <strong>Volcado por linea:</strong> {4} <br />
                        <strong>Fecha: </strong>{5:dd/MM/yyyy} <strong>Hora: </strong>{6:hh:mm} <br />
                    </div>
                </div>
            </div>
    ";
    #endregion

    #region Eventos de página
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriAgrMod();
        CargarLineas();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCodigo.Focus();
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion

    #region Eventos de botones
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        // control de validación
        if (!DatosOk()) return;
        // borramos el campo para evitar problemas
        string rfid = txtCodigo.Text;
        txtCodigo.Text = "";
        // buscar en trzpalets el palet con ese RFID
        Trzpalet palet = (from p in ctx.Trzpalets
                          where p.CRFID == rfid
                          select p).FirstOrDefault<Trzpalet>();
        if (palet == null)
        {
            string mens = String.Format("No se ha encontrado un palet con el RFID({0}) indicado", rfid);
            dvRespuesta.InnerHtml = String.Format(mensError, mens);
        }
        else
        {
            // leer los datos externos que nos hacen falta
            string nomprodu = "";
            string nomvarie = "";
            Variedade variedad = (from v in ctx.Variedades
                                  where v.Codvarie == (uint)palet.Codvarie
                                  select v).FirstOrDefault<Variedade>();
            if (variedad != null)
            {
                nomvarie = variedad.Nomvarie;
                if (variedad.Producto != null)
                    nomprodu = variedad.Producto.Nomprodu;
            }
            // realizar el volcado por la línea que corresponde
            Trzlineas_carga volcado = new Trzlineas_carga();
            volcado.Crfid = palet.CRFID;
            volcado.Fecha = DateTime.Now;
            volcado.Fechahora = DateTime.Now;
            volcado.Idpalet = palet.Idpalet;
            uint linea = uint.Parse(ddlLinea.SelectedValue);
            volcado.Linea = linea;
            volcado.Tipo = (int)palet.Tipo;
            ctx.Add(volcado);
            palet.CRFID = "";
            ctx.SaveChanges();
            dvRespuesta.InnerHtml = String.Format(mensOk,
                palet.CRFID,palet.Idpalet,
                nomprodu,nomvarie,
                linea,
                volcado.Fechahora,volcado.Fechahora
                );
        }

    }
    #endregion

    #region Funciones auxiliares
    protected void CargarLineas()
    {
        ddlLinea.Items.Clear();
        var rs = (from l in ctx.Trzlineas_confeccions
                  select l);
        foreach (Trzlineas_confeccion linea in rs)
        {
            ddlLinea.Items.Add(new ListItem(linea.Nombre,linea.Codlinconfe.ToString()));
        }
        ddlLinea.Items.Add(new ListItem(" ", ""));
        ddlLinea.SelectedValue = "";
    }
    protected bool DatosOk()
    {
        if (!rqCodigo.IsValid || !rqLinea.IsValid)
        {
            dvRespuesta.InnerHtml = String.Format(mensError, "Faltan valores o son incorrectos");
            return false;
        }
        return true;
    }
    #endregion
}
