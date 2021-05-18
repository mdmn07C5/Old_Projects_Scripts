using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewMoveEvent", menuName = "Custom Events/New Move Event")]
public class CreateMoveEvent : ScriptableObject
{
	public List<ScriptableObject> so = new List<ScriptableObject>();

	public void MakeEvents()
	{

	}
}
