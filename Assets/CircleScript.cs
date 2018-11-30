using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour {
	private void Awake()
	{
		GenerateCircle(1,30);
	}

	void GenerateCircle(float radius, int n)
	{
		Mesh mesh = new Mesh();
		//verticies
		List<Vector3> verticiesList = new List<Vector3>();
		float x;
		float y;
		for (int i = 0; i < n; i++)
		{
			x = radius * Mathf.Sin((2 * Mathf.PI * i) / n);
			y = radius * Mathf.Cos((2 * Mathf.PI * i) / n);
			verticiesList.Add(new Vector3(x, y, 0f));
		}

		//triangles
		List<int> trianglesList = new List<int>();
		for (int i = 0; i < n - 2; i++)
		{
			trianglesList.Add(0);
			trianglesList.Add(i + 1);
			trianglesList.Add(i + 2);
		}

		mesh.vertices = verticiesList.ToArray();
		mesh.triangles = trianglesList.ToArray();
		
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = mesh;
	}
}
