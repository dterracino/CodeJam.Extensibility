using System;

using JetBrains.Annotations;

namespace CodeJam.Extensibility.StratFactories
{
	/// <summary>
	/// ��������� ������, ���������������� ������������� ���������.
	/// </summary>
	public interface IExtensionStrategyFactory
	{
		/// <summary>
		/// ������� ���������.
		/// </summary>
		[NotNull]
		IExtensionAttachmentStrategy[] CreateStrategies([NotNull] IServiceProvider provider);
	}
}