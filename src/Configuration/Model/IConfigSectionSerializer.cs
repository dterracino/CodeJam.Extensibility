using System.Xml;

namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ������������ ������ ������������.
	/// </summary>
	public interface IConfigSectionSerializer
	{
		/// <summary>
		/// ��������������� ������.
		/// </summary>
		object Deserialize(XmlReader reader);

		/// <summary>
		/// ������� ������ �� ���������.
		/// </summary>
		object CreateDefaultSection();
	}
}