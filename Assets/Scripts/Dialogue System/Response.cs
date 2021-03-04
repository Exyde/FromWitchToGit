using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Response", fileName = "New Response")]
public class Response : ScriptableObject
{
	[TextArea(3, 25)]
	public string response;

	public Message nextMessage;

	[Range (0, 100)]
	public int auraValue = 0;
}
