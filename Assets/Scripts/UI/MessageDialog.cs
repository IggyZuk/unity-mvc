using System;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : BaseDialog
{
	[SerializeField]
	Text messageText;
	[SerializeField]
	Button closeButton;

	public void Init(string message, System.Action onClose)
	{
		messageText.text = message;
		closeButton.onClick.AddListener(() => { onClose(); });
	}

	internal void Init(object greetingMessage, Action p)
	{
		throw new NotImplementedException();
	}

	public override string GetDialogId()
	{
		return "MessageDialog";
	}
}
