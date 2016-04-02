using System;

using JetBrains.Annotations;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// �������� active part.
	/// </summary>
	public class ActivePartInfo
	{
		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public ActivePartInfo([NotNull] string typeName)
		{
			TypeName = typeName;
			if (typeName == null)
				throw new ArgumentNullException(nameof(typeName));
		}

		/// <summary>
		/// ���, ����������� ����������.
		/// </summary>
		public string TypeName { get; }
	}
}