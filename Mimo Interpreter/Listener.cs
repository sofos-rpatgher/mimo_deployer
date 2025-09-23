using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace Mimo_Interpreter
{
    internal class Listener
    {
        private RichTextBox console;
        private string url;

        public Listener(string url, RichTextBox console)
        {
            this.url = url;
            this.console = console;
            startListeningHttp();
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
            if (console.InvokeRequired)
                console.BeginInvoke(new Action(() => console.AppendText(text + Environment.NewLine)));
            else
                console.AppendText(text + Environment.NewLine);
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
                        SafeLog("------------------------------------------");
                        SafeLog("Cuerpo de la petición POST recibido:");
                        SafeLog(requestBody);
                        SafeLog("------------------------------------------");

                        MimoProgram mimo_program = JsonConvert.DeserializeObject<MimoProgram>(requestBody);
                        SafeLog("Task running: " + mimo_program.batch_iid);
                    }

                    // Build response
                    string responseString = "POST request received successfully!";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                    // Response
                    response.ContentLength64 = buffer.Length;
                    response.StatusCode = (int)HttpStatusCode.OK; // 200 OK
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
