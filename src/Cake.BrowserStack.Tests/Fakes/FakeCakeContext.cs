using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.BrowserStack.Tests.Fakes
{
	public class FakeCakeContext
	{
		ICakeContext context;
		FakeCakeLog log;
		DirectoryPath testsDir;

		public FakeCakeContext()
		{
			testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppContext.BaseDirectory));

			log = new FakeCakeLog();
			var fileSystem = new FileSystem();
			var environment = new CakeEnvironment(new CakePlatform(), new CakeRuntime(), log);
			var globber = new Globber(fileSystem, environment);
			var args = new FakeCakeArguments();
			var config = new Core.Configuration.CakeConfigurationProvider(fileSystem, environment).CreateConfiguration(testsDir, new Dictionary<string, string>());
            var toolRepository = new ToolRepository(environment);
            var toolResolutionStrategy = new ToolResolutionStrategy(fileSystem, environment, globber, config);
            var toolLocator = new ToolLocator(environment, toolRepository, toolResolutionStrategy);
			var processRunner = new ProcessRunner(fileSystem, environment, log, toolLocator, config);
			var registry = new WindowsRegistry();
		    var dataService = new FakeDataService();
            context = new CakeContext(fileSystem, environment, globber, log, args, processRunner, registry, toolLocator, dataService, config);
			context.Environment.WorkingDirectory = testsDir;
		}

		public DirectoryPath WorkingDirectory
		{
			get { return testsDir; }
		}

		public ICakeContext CakeContext
		{
			get { return context; }
		}

		public string GetLogs()
		{
			return string.Join(Environment.NewLine, log.Messages);
		}

		public void DumpLogs()
		{
			foreach (var m in log.Messages)
				Console.WriteLine(m);
		}
	}
}
