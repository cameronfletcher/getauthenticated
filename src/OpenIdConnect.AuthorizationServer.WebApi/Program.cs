namespace OpenIdConnect.AuthorizationServer.WebApi
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = args.Length == 0 ? "http://+:80/api/" : args[0];
            var appHost = new AppHostHttpListener();
            appHost.Init();
            appHost.Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
            Console.ReadKey();
        }
    }
}
