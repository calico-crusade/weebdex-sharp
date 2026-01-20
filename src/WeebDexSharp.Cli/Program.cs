return await new ServiceCollection()
	.AddAppSettings(c => c.AddUserSecrets<Program>())
	.AddSerilog()
	.AddWeebDex(c => c
		.WithCredentials<AuthCredentialsService>())
	.AddSingleton<AuthOptionsCache>()
	.Cli(args, c => c
		.Add<DefaultVerb>()
		.Add<TestVerb>());