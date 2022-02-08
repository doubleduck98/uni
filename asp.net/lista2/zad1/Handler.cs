using System.IO;
using System.Web;

namespace lista2
{
    public class Handler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext ctx)
        {
            ctx.Response.AppendHeader("Content-type", "text/html");
            ctx.Response.Write($"{ctx.Request.Url}<br/>");
            foreach (var header in ctx.Request.Headers)
            {
                ctx.Response.Write($"header: {header}<br/>");
            }
            ctx.Response.Write($"HTTP verb: {ctx.Request.HttpMethod}<br/>");
            if (ctx.Request.HttpMethod == "POST")
            {
            //@zadanie 2: tak można odczytać parametry metody POST:
                using (var sr = new StreamReader(ctx.Request.InputStream))
                {
                    var respBody = sr.ReadToEnd();
                    if (respBody.Length > 0)
                        ctx.Response.Write($"body: {respBody}<br/>");
                }
            }
            /*@zadanie 2: tak można wypisać parametry dla requesta GET
            foreach (var param in ctx.Request.QueryString)
            {
                param...
            }
            
            albo pojedyncze ctx.Request.QueryString["nazwaParametru"]
            */
        }
    }
}