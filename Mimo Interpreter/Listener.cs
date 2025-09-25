using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Web.Services.Description;

namespace Mimo_Interpreter
{
    internal class Listener
    {
        private readonly SynchronizationContext ui;
        private RichTextBox console;
        private string url;

        public Listener(string url, RichTextBox console)
        {
            this.url = url;
            this.console = console;
            this.ui = SynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();

            startListeningHttp(); // fire-and-forget, no async void
        
        }

        private async void startListeningHttp()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);

            try
            {
                listener.Start();
                console.AppendText($"Listening on {url}...");

                while (true)
                {
                    HttpListenerContext context = await listener.GetContextAsync();

                    _ = Task.Run(() => ProcessRequest(context));
                }
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine($"Error al iniciar el servidor: {ex.Message}");
            }
            finally
            {
                if (listener.IsListening)
                {
                    listener.Stop();
                }
            }
        }

        private void SafeLog(string text)
        {
            if (console.IsDisposed) return;
            ui.Post(_ => console.AppendText(text + Environment.NewLine), null);
        }

        private async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");

            SafeLog($"Request received: {request.HttpMethod} {request.Url}");

            if (request.HttpMethod == "OPTIONS")
            {
                response.StatusCode = (int)HttpStatusCode.NoContent; // 204
                response.Close();
                return;
            }

            if (request.HttpMethod == "POST")
            {
                try
                {
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        string requestBody = await reader.ReadToEndAsync();


                        MimoProgram mimo_program = JsonConvert.DeserializeObject<MimoProgram>(requestBody);
                        Interpreter interpreter = new Interpreter(this.console, "C:\\Program Files\\SAP\\FrontEnd\\SAPGUI\\sapshcut.exe","RPATGHER","Patgher2003$","300");
                        interpreter.mimo_program = mimo_program;
                        interpreter.interpret();
                    }

                    // Build JSON response
                    var responseObject = new { message = "POST request received successfully!" };
                    string responseString = JsonConvert.SerializeObject(responseObject);
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                    // Response
                    response.ContentType = "application/json";
                    response.ContentLength64 = buffer.Length;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    using (Stream output = response.OutputStream)
                    {
                        await output.WriteAsync(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception ex)
                {
                    SafeLog($"Error processing POST request: {ex.Message}");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500 Internal Server Error
                }
            }
            else
            {
                string responseString = "This server only accepts POST requests.";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.StatusCode = (int)HttpStatusCode.OK;
                using (Stream output = response.OutputStream)
                {
                    await output.WriteAsync(buffer, 0, buffer.Length);
                }
            }

            response.Close();
        }

    }
}
