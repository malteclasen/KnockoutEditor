using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	public class CassiniDevServer : IServer
	{
		private const string _applicationName = "RecipeEditor";
		private readonly int _port;
		private readonly CassiniDev.CassiniDevServer _server;

		static int FreeTcpPort()
		{
			var l = new TcpListener(IPAddress.Loopback, 0);
			l.Start();
			var port = ((IPEndPoint)l.LocalEndpoint).Port;
			l.Stop();
			return port;
		}

		private string SolutionFolder
		{
			get
			{
				if (NCrunch.Framework.NCrunchEnvironment.NCrunchIsResident())
					return Path.GetDirectoryName(NCrunch.Framework.NCrunchEnvironment.GetOriginalSolutionPath());
				return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
			}
		}

		private string GetApplicationPath(string applicationName)
		{
			return Path.Combine(SolutionFolder, applicationName);
		}

		public CassiniDevServer()
		{
			_port = FreeTcpPort();
			_server = new CassiniDev.CassiniDevServer();
			_server.StartServer(GetApplicationPath(_applicationName), _port, "/", "localhost");
		}

		public void Dispose()
		{
			_server.StopServer();
			GC.SuppressFinalize(this);
		}

		~CassiniDevServer()
		{
			Dispose();
		}

		public Uri Root
		{
			get { return new Uri("http://localhost:" + _port); }
		}
	}
}
