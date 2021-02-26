using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "DialogueSystem/Message", fileName = "New Message")]
public class Message : ScriptableObject
{
	[TextArea (3, 25)]
	public string message;
}