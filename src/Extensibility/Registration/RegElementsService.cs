using System;
using System.Collections.Generic;

namespace CodeJam.Extensibility.Registration
{
	/// <summary>
	/// ������� ���������� <see cref="IRegElementsService{EI}"/>
	/// </summary>
	public class RegElementsService<TInfo> : IRegElementsService<TInfo> where TInfo : class
	{
		private readonly List<TInfo> _elements = new List<TInfo>();

		#region IRegElementsService<EI> Members
		/// <summary>
		/// ���������������� �������.
		/// </summary>
		public virtual void Register(TInfo elementInfo)
		{
			if (elementInfo == null)
				throw new ArgumentNullException(nameof(elementInfo));
			_elements.Add(elementInfo);
		}

		/// <summary>
		/// �������� ������ ������������������ ���������.
		/// </summary>
		public virtual TInfo[] GetRegisteredElements()
		{
			return _elements.ToArray();
		}
		#endregion
	}
}