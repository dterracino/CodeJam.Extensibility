using System;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// ������� ���������� �������� ������������ ����������.
	/// </summary>
	public abstract class NamedElementInfo : KeyedElementInfo<string>
	{
		/// <summary>
		/// �������������� ���������.
		/// </summary>
		protected NamedElementInfo(string name, Type type)
			: base(type, name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));
		}

		/// <summary>
		/// ��� ����������.
		/// </summary>
		public string Name => Key;
	}
}