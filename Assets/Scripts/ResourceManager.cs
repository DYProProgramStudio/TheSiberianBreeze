using UnityEngine;

public class ResourceManager {
	private const int Length = 2;
	private static readonly string[] Names = { "soil", "tree" };
	private static readonly Rect[] Pos = {
		new Rect(0, 0, 128, 128),
		new Rect(0, 0, 128, 160)
	};
	private static readonly ushort[] PPU = { 128, 128 };

	public static Sprite Load(int i) {
		if ((i >= 0) && (i < Length))
			return Sprite.Create(Resources.Load(Names[i]) as Texture2D, Pos[i], new Vector2(0, 0), PPU[i]);
		return null;
	}
}
