namespace CodeJam.Extensibility.Registration
{
	/// <summary>
	/// ��������� ������������ ��������.
	/// </summary>
	public interface IKeyedElementInfo<out TKey>
	{
		/// <summary>
		/// ����.
		/// </summary>
		TKey Key { get; }
	}
}