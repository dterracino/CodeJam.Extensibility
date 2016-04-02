namespace CodeJam.Extensibility.Registration
{
	/// <summary>
	/// ������ ����������� ����������� ���������.
	/// </summary>
	public interface IRegKeyedElementsService<in TKey, TInfo> : IRegElementsService<TInfo>
		where TInfo : IKeyedElementInfo<TKey>
	{
		/// <summary>
		/// ���������, ���� �� ������������������ ������� � ��������� ������.
		/// </summary>
		bool ContainsElement(TKey key);

		/// <summary>
		/// ���������� ������� �� ��� �����.
		/// </summary>
		TInfo GetElement(TKey key);
	}
}