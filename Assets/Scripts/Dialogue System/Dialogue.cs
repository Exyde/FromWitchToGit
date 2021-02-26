using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "DialogueSystem/Dialogue", fileName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
	public Message[] dialogue;
}
