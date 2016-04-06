using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CodeJam.Services;

using JetBrains.Annotations;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// ������� ���������� ��������� ����������.
	/// </summary>
	public class ExtensionManager : IExtensionManager, IServiceProvider
	{
		private readonly ServiceContainer _serviceContainer;

		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public ExtensionManager([CanBeNull] IServiceProvider serviceProvider)
		{
			_serviceContainer =
				serviceProvider == null
					? new ServiceContainer()
					: new ServiceContainer(serviceProvider);
			_serviceContainer.Publish<IExtensionManager>(this);
		}

		/// <summary>
		/// ���������� ServiceManager.
		/// </summary>
		protected ServiceContainer ServiceContainer => _serviceContainer;

		#region IExtensionManager Members
		/// <summary>
		/// ��������� ������.
		/// </summary>
		public void Scan(IExtensionAttachmentStrategy strategy, [NotNull] params Assembly[] assemblies)
		{
			if (strategy == null)
				throw new ArgumentNullException(nameof(strategy));
			if (assemblies == null)
				throw new ArgumentNullException(nameof(assemblies));

			foreach (var asm in assemblies)
			{
				var ctx = new ExtensionAttachmentContext(ServiceContainer, this, asm);
				foreach (var attr in CustomAttributeData.GetCustomAttributes(asm))
					strategy.Attach(ctx, attr);
				Scan(asm, asm.GetTypes(), strategy);
			}
		}

		/// <summary>
		/// Scan specific type.
		/// </summary>
		public void Scan(
			[NotNull] IExtensionAttachmentStrategy strategy,
			[NotNull] params Type[] types)
		{
			if (strategy == null) throw new ArgumentNullException(nameof(strategy));
			if (types == null) throw new ArgumentNullException(nameof(types));
			foreach (var group in types.GroupBy(t => t.Assembly))
				Scan(group.Key, group, strategy);
		}

		private void Scan(Assembly asm, IEnumerable<Type> types, IExtensionAttachmentStrategy strategy)
		{
			foreach (var type in types)
			{
				var ctx = new ExtensionAttachmentContext(ServiceContainer, this, asm, type);
				foreach (var attr in CustomAttributeData.GetCustomAttributes(type))
					strategy.Attach(ctx, attr);
			}
		}
		#endregion

		#region Implementation of IServiceProvider
		/// <summary>
		/// See <see cref="IServiceProvider.GetService"/>
		/// </summary>
		public object GetService(Type serviceType)
		{
			return _serviceContainer.GetService(serviceType);
		}
		#endregion
	}
}