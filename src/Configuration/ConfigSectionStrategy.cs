using System;

using CodeJam.Extensibility.Registration;

using Rsdn.SmartApp;
using Rsdn.SmartApp.Configuration;

namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ��������� ����������� ������ ������������.
	/// </summary>
	public class ConfigSectionStrategy
		: RegKeyedElementsStrategy<Type, ConfigSectionInfo, ConfigSectionAttribute>
	{
		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public ConfigSectionStrategy(IServicePublisher publisher)
			: base(publisher)
		{}

		/// <summary>
		/// ������� �������.
		/// </summary>
		public override ConfigSectionInfo CreateElement(ExtensionAttachmentContext context, ConfigSectionAttribute attr)
		{
			return
				new ConfigSectionInfo(
					attr.Name,
					attr.Namespace,
					attr.AllowMerge,
					context.Type,
					attr.CreateSerializer(context.Type));
		}
	}
}