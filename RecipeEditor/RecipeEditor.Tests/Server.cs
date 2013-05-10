using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace RecipeEditor.Tests
{
	sealed class Server : IDisposable
	{
		private readonly int _iisPort;
		private const string _applicationName = "RecipeEditor";
		private readonly Process _iisProcess;

		static int FreeTcpPort()
		{
			var l = new TcpListener(IPAddress.Loopback, 0);
			l.Start();
			var port = ((IPEndPoint)l.LocalEndpoint).Port;
			l.Stop();
			return port;
		}

		public Server()
		{
			var applicationPath = GetApplicationPath(_applicationName);
			var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			_iisPort = FreeTcpPort();

			_iisProcess = new Process
				{
					StartInfo =
						{
							FileName = programFiles + "\\IIS Express\\iisexpress.exe",
							Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, _iisPort),
							WindowStyle = ProcessWindowStyle.Minimized
						}
				};
			_iisProcess.Start();
			if(_iisProcess.HasExited)
				throw new Exception("could not run IIS Express with the following arguments: " + _iisProcess.StartInfo.Arguments);
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

		public void Dispose()
		{
			if (_iisProcess.HasExited == false)
			{
				_iisProcess.Kill();
			}
			_iisProcess.Dispose();
			GC.SuppressFinalize(this);
		}

		~Server()
		{
			Dispose();
		}

		public Uri Root
		{
			get { return new Uri("http://localhost:" + _iisPort); }
		}
	}


}
