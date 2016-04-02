using System;

using CodeJam.Extensibility.Registration;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// ���������� � ������������������ ������� ���������.
	/// </summary>
	public class ExtensionStrategyFactoryInfo : IKeyedElementInfo<Type>
	{
		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public ExtensionStrategyFactoryInfo(Type type)
		{
			Type = type;
		}

		/// <summary>
		/// ��� �������.
		/// </summary>
		public Type Type { get; }

		#region IKeyedElementInfo<Type> Members
		/// <summary>
		/// ����.
		/// </summary>
		Type IKeyedElementInfo<Type>.Key => Type;
		#endregion
	}
}