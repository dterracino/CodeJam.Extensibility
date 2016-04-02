namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ���������, ��������� � XML-�������������� ������������.
	/// </summary>
	public static class ConfigXmlConstants
	{
		/// <summary>
		/// XML-���������.
		/// </summary>
		public const string XmlNamespace = "http://rsdn.ru/CodeJam/Extensibility/ConfigSectionSchema.xsd";

		/// <summary>
		/// ��� ������� �� ������.
		/// </summary>
		public const string XmlSchemaResource =
			"CodeJam.Extensibility.Configuration.Model.ConfigSectionSchema.xsd";

		/// <summary>
		/// ��� ���� � ��������.
		/// </summary>
		public const string IncludeTagName = "include";

		/// <summary>
		/// ��� ���� � ����������.
		/// </summary>
		public const string VariableTagName = "var";

		/// <summary>
		/// ��� �������� � ������ ����������.
		/// </summary>
		public const string VariableNameAttribute = "name";
	}
}