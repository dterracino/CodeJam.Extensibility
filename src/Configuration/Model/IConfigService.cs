namespace CodeJam.Extensibility.Configuration
{
	/// <summary>
	/// ������ ������������.
	/// </summary>
	public interface IConfigService
	{
		/// <summary>
		/// �������� ���������� ������.
		/// </summary>
		T GetSection<T>();

		/// <summary>
		/// ���������� ��� ��������� ������������.
		/// </summary>
		event EventHandler<IConfigService> ConfigChanged;
	}
}