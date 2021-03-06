using System;
using System.Linq;
using System.Reflection;
using System.Xml.Schema;
using System.Xml.Serialization;

using CodeJam.Collections;

namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// �������� ������ ������������ � �������������� <see cref="XmlSerializer"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class XmlSerializerSectionAttribute : ConfigSectionAttribute
	{
		private static readonly ILazyDictionary<Type, XmlRootAttribute> _rootAttrs =
			LazyDictionary.Create<Type, XmlRootAttribute>(
				type =>
				{
					var xras =
						type
							.GetCustomAttributes<XmlRootAttribute>(true)
							.ToArray();
					return xras.Length == 0 ? null : xras[0];
				},
				true);
		private static readonly ILazyDictionary<SchemaLocation, XmlSchema> _schemas =
			LazyDictionary.Create<SchemaLocation, XmlSchema>(LoadSchema, true);

		private static XmlSchema LoadSchema(SchemaLocation loc)
		{
			var schemaRes = loc.Assembly.GetManifestResourceStream(loc.ResourceName);
			if (schemaRes == null)
				throw new ArgumentException("Resource '" + loc.ResourceName + "' not found in assembly '"
					+ loc.Assembly.FullName + "'");
			return XmlSchema.Read(schemaRes, null);
		}

		/// <summary>
		/// �������������� ��������� �����, ����������� ��������.
		/// </summary>
		public XmlSerializerSectionAttribute(Type implType)
			: base(GetSectionName(implType), GetSectionNamespace(implType))
		{
			ImplementationType = implType;
		}

		/// <summary>
		/// �������������� ��������� ������ ����, ������������ ��������.
		/// </summary>
		public XmlSerializerSectionAttribute(string implType)
			: this(Type.GetType(implType, true))
		{}

		/// <summary>
		/// ���, ����������� ������������. ������ ���� ������������� � XML.
		/// </summary>
		public Type ImplementationType { get; }

		/// <summary>
		/// ��� ������� �� ������.
		/// </summary>
		public string SchemaResource { get; set; }

		/// <summary>
		/// ���������� ����� ������������.
		/// </summary>
		protected virtual XmlSchema GetSchema(Type contractType)
		{
			return string.IsNullOrEmpty(SchemaResource)
				? null
				: _schemas[new SchemaLocation(contractType.Assembly, SchemaResource)];
		}

		private static string GetSectionName(Type type)
		{
			var xra = _rootAttrs[type];
			return xra == null ? type.Name : xra.ElementName; 
		}

		private static string GetSectionNamespace(Type type)
		{
			var xra = _rootAttrs[type];
			return xra.Namespace ?? ""; 
		}

		/// <summary>
		/// ������� �����������.
		/// </summary>
		public override IConfigSectionSerializer CreateSerializer(Type contractType)
		{
			return new XmlSectionSerializer(ImplementationType, GetSchema(contractType));
		}

		#region SchemaLocation struct
		private class SchemaLocation
		{
			public SchemaLocation(Assembly asm, string resName)
			{
				Assembly = asm;
				ResourceName = resName;
			}

			public Assembly Assembly { get; }

			public string ResourceName { get; }

			public override bool Equals(object obj)
			{
				var loc = (SchemaLocation)obj;
				return Assembly == loc.Assembly && ResourceName == loc.ResourceName;
			}

			public override int GetHashCode()
			{
				return Assembly.GetHashCode() ^ ResourceName.GetHashCode();
			}
		}
		#endregion
	}
}
