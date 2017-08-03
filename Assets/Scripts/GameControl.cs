public static class GameControl {
	public const int MENU = 0;
	public const int GAME = 1;

	private static int status = MENU;

	private static int mapType = Map.FIELD;
	private static int mapId = 0;
	private static Map map = null;

	public static int MapType {
		get { return mapType; }
	}

	public static int MapId {
		get { return mapId; }
	}

	public static Map GetMap() {
		if (map == null) {
			map = MapType == Map.FIELD ? Map.GenerateFieldMap(MapId) : new Map(MapId);
		}
		return map;
	}

	public static void SetMap(int type, int id) {
		mapType = type;
		mapId = id;
		map = null;
	}

	public static int Status {
		set { status = value; }
		get { return status; }
	}
}
