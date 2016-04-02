namespace CodeJam.Extensibility
{
	/// <summary>
	/// ���������� ������� ��� ����������.
	/// </summary>
	public delegate void EventHandler<in TSender>(TSender sender);

	/// <summary>
	/// ���������� ������� � �����������.
	/// </summary>
	public delegate void EventHandler<in TSender, in TParams>(TSender sender, TParams eventParams);
}