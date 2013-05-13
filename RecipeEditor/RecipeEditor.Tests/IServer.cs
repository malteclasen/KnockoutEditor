using System;

namespace RecipeEditor.Tests
{
	internal interface IServer : IDisposable
	{
		Uri Root { get; }
	}
}