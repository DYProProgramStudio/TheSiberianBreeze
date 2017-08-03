public class Map {
	public const int URBAN = 0;
	public const int FIELD = 1;

	private int id, type, seed;
	private int[] resources = { 1, 0 };
	private int[,] map, typeMap;

	public int Id {
		get { return id; }
	}

	public int Type {
		get { return type; }
	}

	public int Width {
		get { return map.GetLength(0); }
	}

	public int Height {
		get { return map.GetLength(1); }
	}

	public int Seed {
		get { return seed; }
	}

	public int[] Resources {
		get { return resources; }
	}

	public Map(int id) {
		type = URBAN;
	}

	private Map(int id, int[,] map, int[,] typeMap, int seed) {
		this.id = id;
		this.map = map;
		this.typeMap = typeMap;
		type = FIELD;
		this.seed = seed;
	}

	public int[,] GetMap() {
		return map;
	}

	public int[,] GetTypeMap() {
		return typeMap;
	}

	public static Map GenerateFieldMap(int id) {
		Perlin p = new Perlin(100, 100);
		int[,] map = new int[100, 100];
		int[,] typeMap = new int[100, 100];
		float[,] perlin = p.GetMap();
		for (int i = 0; i < 100; ++i)
			for (int j = 0; j < 100; ++j)
				map[i, j] = 1 - (typeMap[i, j] = perlin[i, j] < -.2f ? 1 : 0);
		return new Map(id, map, typeMap, p.GetSeed());
	}
}
