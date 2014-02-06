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

public partial class Consulta : System.Web.UI.Page
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
                    <h3 class='panel-title'>Encontrado</h3>
                </div>
                <div class='panel-body'>
                    <div class='panel-content'>
                        <strong>RFID: </strong>{0} <strong>Código Palet:</strong>{1}<br />
                        <strong>Socio: </strong>({2}) {3}<br />
                        <strong>Producto: </strong>{4} <strong>Variedad: </strong>{5} <br />
                        <strong>Kilos:</strong>{6} <strong>Cajones: </strong>{7} <br />
                        <strong>Fecha: </strong>{8:dd/MM/yyyy} <strong>Hora: </strong>{9:hh:mm} <br />
                        <strong>Campo: </strong>{10} <strong>Nota entrada: </strong>{11}
                    </div>
                </div>
            </div>
    ";
    #endregion

    #region Eventos de página
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriAgrMod();
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
            string nomsocio = "";
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
            Rsocio socio = (from s in ctx.Rsocios
                            where s.Codsocio == (uint)palet.Codsocio
                            select s).FirstOrDefault<Rsocio>();
            if (socio != null)
                nomsocio = socio.Nomsocio;
            // montar el mensaje
            dvRespuesta.InnerHtml = String.Format(mensOk,
                palet.CRFID, palet.Idpalet,
                palet.Codsocio, nomsocio,
                nomprodu, nomvarie,
                palet.Numkilos, palet.Numcajones,
                palet.Fecha, palet.Hora,
                palet.Codcampo, palet.Numnotac
                );
         }

    }
    #endregion
    #region Funciones auxiliares
    protected bool DatosOk()
    {
        if (!rqCodigo.IsValid)
        {
            dvRespuesta.InnerHtml = String.Format(mensError, "Faltan valores o son incorrectos");
            return false;
        }
        return true;
    }
    #endregion
}
