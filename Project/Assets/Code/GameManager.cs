using UnityEngine;

public class GameManager
{
    internal CharController Player;
    internal Camera CurrentCam
    {
        get { return Player.MainCam; }
    }

    private CharacterStats characterStats;
    internal CharacterStats CharacterStats
    {
        get { return characterStats ?? (characterStats = new CharacterStats()); }
    }

    private Inventory inventory;
    internal Inventory Inventory
    {
        get { return inventory ?? (inventory = new Inventory()); }
    }

	#region Access and cctor
	private static GameManager instance;
	public static GameManager Instance
	{
		get { return instance ?? (instance = new GameManager()); }
	}
	private GameManager() { }

	internal void RegisterPlayer(CharController charController)
	{
		Player = charController;
	}
	#endregion
}
