using System;

using CodeJam.Collections;
using CodeJam.Extensibility.Registration;
using CodeJam.Extensibility.StratFactories;
using CodeJam.Services;

namespace CodeJam.Extensibility
{
	using FactoriesSvc = IRegKeyedElementsService<Type, ExtensionStrategyFactoryInfo>;

	/// <summary>
	/// ��������� ����������� ������ ���������.
	/// </summary>
	public class StrategyFactoryStrategy :
		RegKeyedElementsStrategy<Type, ExtensionStrategyFactoryInfo,ExtensionStrategyFactoryAttribute>
	{
		private static readonly ILazyDictionary<Type, IExtensionStrategyFactory> _factories =
			LazyDictionary.Create<Type, IExtensionStrategyFactory>(
				type => (IExtensionStrategyFactory) Activator.CreateInstance(type),
				true);

		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public StrategyFactoryStrategy(IServicePublisher publisher) : base(publisher)
		{}

		/// <summary>
		/// ������� �������.
		/// </summary>
		public override ExtensionStrategyFactoryInfo CreateElement(
			ExtensionAttachmentContext context,
			ExtensionStrategyFactoryAttribute attr)
		{
			if (!typeof (IExtensionStrategyFactory).IsAssignableFrom(context.Type))
				throw new InvalidExtensionTypeException(
					$"Strategy factory must implement '{typeof (IExtensionStrategyFactory)}' interface");
			return new ExtensionStrategyFactoryInfo(context.Type);
		}

		/// <summary>
		/// ����������� ���� � ��������� �������� ���������.
		/// </summary>
		public static void ScanWithFactory(Type factoryType,
			IServiceProvider provider,
			IExtensionManager extensionManager,
			Type[] types)
		{
			var svc = provider.GetRequiredService<FactoriesSvc>();
			ScanWithFactory(provider, extensionManager, svc.GetElement(factoryType), types);
		}

		/// <summary>
		/// ����������� �� ����� ���������.
		/// </summary>
		public static void ScanWithAllFactories(
			IServiceProvider provider,
			IExtensionManager extensionManager,
			Type[] types)
		{
			var svc = provider.GetService<FactoriesSvc>();
			// if no factories registered - do nothing
			if (svc == null)
				return;
			foreach (var factoryInfo in svc.GetRegisteredElements())
				ScanWithFactory(provider, extensionManager, factoryInfo, types);
		}

		/// <summary>
		/// ���������������� ��� ������� � ����������� ������ � ����.
		/// </summary>
		public static void RegisterAndScan(
			IServicePublisher publisher,
			IExtensionManager extensionManager,
			Type[] types)
		{
			extensionManager.Scan(new StrategyFactoryStrategy(publisher), types);
			ScanWithAllFactories(publisher, extensionManager, types);
		}

		private static void ScanWithFactory(
			IServiceProvider provider,
			IExtensionManager extManager,
			ExtensionStrategyFactoryInfo factoryInfo,
			Type[] types)
		{
			var factory = _factories[factoryInfo.Type];
			foreach (var strat in factory.CreateStrategies(provider))
				extManager.Scan(strat, types);
		}
	}
}