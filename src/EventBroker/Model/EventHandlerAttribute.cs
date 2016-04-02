using System;

using JetBrains.Annotations;

namespace CodeJam.Extensibility.EventBroker
{
	/// <summary>
	/// �������, ���������� ���������� �������.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	[MeansImplicitUse]
	public class EventHandlerAttribute : Attribute
	{
		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public EventHandlerAttribute(string eventName)
		{
			EventName = eventName;
		}

		/// <summary>
		/// ��� �������.
		/// </summary>
		public string EventName { get; }
	}
}