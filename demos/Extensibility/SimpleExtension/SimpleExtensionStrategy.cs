using System.IO;

using CodeJam.Extensibility.SystemType;

namespace CodeJam.Extensibility.Demos
{
	internal class SimpleExtensionStrategy
		: AttachmentStrategyBase<SimpleExtensionAttribute>
	{
		private readonly TextWriter _writer;

		public SimpleExtensionStrategy(TextWriter writer)
		{
			_writer = writer;
		}

		/// <summary>
		/// ���������� ����������.
		/// </summary>
		protected override void Attach(ExtensionAttachmentContext context, SimpleExtensionAttribute attribute)
		{
			_writer.WriteLine($"{attribute.Name}({context.Type.FullName})");
		}
	}
}
