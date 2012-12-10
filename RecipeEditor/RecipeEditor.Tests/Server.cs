using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	class Server : IDisposable
	{
		private const int _iisPort = 2020;
		private const string _applicationName = "RecipeEditor";

		private Process _iisProcess;
		public Server()
		{
			var applicationPath = GetApplicationPath(_applicationName);
			var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

			_iisProcess = new Process();
			_iisProcess.StartInfo.FileName = programFiles + "\\IIS Express\\iisexpress.exe";
			_iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, _iisPort);
			_iisProcess.Start();
		}

		private string SolutionFolder
		{
			get { return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))); }
		}

		protected virtual string GetApplicationPath(string applicationName)
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
