using System;
using UnityEngine;
using Random = System.Random;

public class Perlin {
	public const int SIZE = 8;
	public const int LENGTH = 1 << SIZE;
	public const int MASK = LENGTH - 1;

	private int seed;
	private Random rnd;
	private float[,] map;
	private int[] p;
	private Vector2[] g;

	public static float SmoothCurve(float t) {
		// return (float)(t * t * (3. - 2. * t));
		return t * t * (3f - 2f * t);
	}

	public Perlin(int width, int height) : this(width, height, 7) {
	}

	public Perlin(int width, int height, int wavelen) : this(width, height, wavelen, Guid.NewGuid().GetHashCode()) {
	}

	public Perlin(int width, int height, int wavelen, int seed) {
		this.seed = seed;
		rnd = new Random(seed);
		p = new int[LENGTH];
		g = new Vector2[LENGTH];
		map = new float[width, height];
		for (int i = 0; i < LENGTH; ++i) {
			p[i] = i;
			float x = (float)rnd.NextDouble() * 2 - 1;
			float y = (float)rnd.NextDouble() * 2 - 1;
			g[i] = new Vector2(x, y).normalized;
		}
		for (int i = 0; i < LENGTH; ++i) {
			int t = p[i], j = rnd.Next(256);
			p[i] = p[j];
			p[j] = t;
		}
		for (int x = 0; x < width; ++x) {
			for (int y = 0; y < height; ++y) {
				int x0 = x - x % wavelen, x1 = x0 + wavelen;
				int y0 = y - y % wavelen, y1 = y0 + wavelen;
				float s = Vector2.Dot(g[(x0 + p[y0 & MASK]) & MASK], new Vector2(x - x0, y - y0));
				float t = Vector2.Dot(g[(x1 + p[y0 & MASK]) & MASK], new Vector2(x - x1, y - y0));
				float u = Vector2.Dot(g[(x0 + p[y1 & MASK]) & MASK], new Vector2(x - x0, y - y1));
				float v = Vector2.Dot(g[(x1 + p[y1 & MASK]) & MASK], new Vector2(x - x1, y - y1));
				float sx = SmoothCurve((float)(x - x0) / wavelen), sy = SmoothCurve((float)(y - y0) / wavelen);
				map[x, y] = Mathf.Lerp(Mathf.Lerp(s, t, sx), Mathf.Lerp(u, v, sx), sy) * wavelen / 1.41421356f;
				// Value bewteen -1 ~ 1
			}
		}
	}

	public int GetSeed() {
		return seed;
	}

	public float[,] GetMap() {
		return map;
	}
}
