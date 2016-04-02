using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using CodeJam.Collections;

namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ����������� ������ ��� ������ <see cref="XmlSerializer"/>
	/// </summary>
	public class XmlSectionSerializer : IConfigSectionSerializer
	{
		private static readonly ILazyDictionary<Type, XmlSerializer> _xmlSerializers =
			LazyDictionary.Create<Type, XmlSerializer>(type => new XmlSerializer(type), true);

		private readonly Type _contractType;
		private readonly XmlSchema _schema;

		/// <summary>
		/// �������������� ��������� ����� ��������� � ������.
		/// </summary>
		public XmlSectionSerializer(Type contractType, XmlSchema schema)
		{
			_contractType = contractType;
			_schema = schema;
		}

		/// <summary>
		/// �������������� ��������� ����� ���������.
		/// </summary>
		public XmlSectionSerializer(Type contractType) : this(contractType, null)
		{}

		#region IConfigSectionSerializer Members
		/// <summary>
		/// ��������������� ������.
		/// </summary>
		public object Deserialize(XmlReader reader)
		{
			var xs = _xmlSerializers[_contractType];
			if (_schema != null)
			{
				var rdrSettings = new XmlReaderSettings();
				rdrSettings.Schemas.Add(_schema);
				rdrSettings.ValidationType = ValidationType.Schema;
				reader = XmlReader.Create(reader, rdrSettings);
			}
			return xs.Deserialize(reader);
		}

		/// <summary>
		/// ������� ������ �� ���������.
		/// </summary>
		public object CreateDefaultSection()
		{
			return Activator.CreateInstance(_contractType);
		}
		#endregion
	}
}