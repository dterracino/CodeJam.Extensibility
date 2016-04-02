using System;

using CodeJam.Extensibility.StratFactories;

using JetBrains.Annotations;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// �������, ���������� ���������� <see cref="IExtensionStrategyFactory"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	[MeansImplicitUse]
	[BaseTypeRequired(typeof (IExtensionStrategyFactory))]
	public class ExtensionStrategyFactoryAttribute : Attribute
	{
	}
}