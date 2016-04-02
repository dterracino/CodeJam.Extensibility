using System;

using JetBrains.Annotations;

namespace CodeJam.Extensibility.EventBroker
{
	/// <summary>
	/// �������, ���������� �������� �������.
	/// </summary>
	[AttributeUsage(AttributeTargets.Event | AttributeTargets.Property, AllowMultiple = true)]
	[MeansImplicitUse]
	public class EventSourceAttribute : Attribute
	{
		/// <summary>
		/// Initialize instance.
		/// </summary>
		public EventSourceAttribute(string eventName)
		{
			EventName = eventName;
		}

		/// <summary>
		/// Event name.
		/// </summary>
		public string EventName { get; }
	}
}