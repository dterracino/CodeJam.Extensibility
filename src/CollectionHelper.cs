using System;
using System.Collections.Generic;

namespace CodeJam.Extensibility
{
	/// <summary>
	/// ������� ��� ������ � �����������.
	/// </summary>
	public static class CollectionHelper
	{
		#region Delegates
		/// <summary>
		/// �������, ����������� ����� �������������� ��������� � �������.
		/// </summary>
		public delegate TKey GetKey<out TKey, in TValue>(TValue source);

		/// <summary>
		/// ��������.
		/// </summary>
		public delegate T2 Selector<in T1, out T2>(T1 source);
		#endregion

		/// <summary>
		/// ����������� ������� ��������� � �������� ������ ��� ������ ����������� ��������.
		/// </summary>
		public static TOut[] ConvertAll<TIn, TOut>(this ICollection<TIn> collection,
			Converter<TIn, TOut> converter)
		{
			var res = new TOut[collection.Count];
			var i = 0;
			foreach (var elem in collection)
			{
				res[i] = converter(elem);
				i++;
			}
			return res;
		}

		/// <summary>
		/// ���������� ����������� ������� ���������.
		/// </summary>
		public static Comparison<T> ReverseComparision<T>(Comparison<T> srcComparision)
		{
			return
				(e1, e2) =>
					{
						var cr = srcComparision(e1, e2);
						return cr > 0 ? -1 : cr < 0 ? 1 : 0;
					};
		}
	}
}