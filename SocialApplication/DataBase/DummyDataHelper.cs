

public static class DummyDataHelper
{
	private const string DummyDataInsertedKey = "DummyDataInserted";

	public static bool IsDummyDataInserted()
	{
		return Preferences.ContainsKey(DummyDataInsertedKey);
	}

	public static void SetDummyDataInserted()
	{
		Preferences.Set(DummyDataInsertedKey, true);
	}
}