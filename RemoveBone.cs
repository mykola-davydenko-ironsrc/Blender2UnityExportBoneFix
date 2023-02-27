using UnityEditor;
using UnityEngine;

public class RemoveBone : AssetPostprocessor
{
	void OnPostprocessModel(GameObject g)
	{
		Transform extraBone = FindArmature(g);
		if (extraBone == null) Debug.Log("No extra Armature bone found during import of " + g.name);
		else
		{
			extraBone.GetChild(0).parent = extraBone.parent;
			Object.DestroyImmediate(extraBone.gameObject);
		}
	}
	Transform FindArmature(GameObject g)
	{
		if (g.transform.childCount > 0)
		{
			for (int i = 0; i < g.transform.childCount; i++)
			{
				Debug.Log(g.name);
				if (g.name == "Armature")
				{
					return g.transform;
				}
				var childArmmature = FindArmature(g.transform.GetChild(i).gameObject);
				if (childArmmature != null) return childArmmature;
			}
			return null;
		}
		else
		{
			return null;
		}
	}
}