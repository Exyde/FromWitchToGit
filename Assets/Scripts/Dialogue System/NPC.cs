using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
	public string NPCName;

	[TextArea(3, 15)]
	public string[] messages;

	[TextArea(3, 15)]
	public string[] playerMessages;


}
