return await new ServiceCollection()
	.AddAppSettings()
	.AddSerilog()
	.AddWeebDex(c => c
		.WithCredentials<AuthCredentialsService>())
	.AddSingleton<AuthOptionsCache>()
	.Cli(args, c => c
		.Add<DefaultVerb>()
		.Add<TestVerb>());