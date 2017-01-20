using System.Collections.Generic;
using UnityEngine;

public class RootUI : MonoBehaviour
{
	[SerializeField]
	Transform dialogsRoot;

	Dictionary<string, BaseDialog> dialogs = new Dictionary<string, BaseDialog>();

	public T AddDialog<T>(string dialogPath) where T : BaseDialog
	{
		GameObject prefab = Resources.Load<GameObject>(dialogPath);
		GameObject go = Object.Instantiate<GameObject>(prefab);
		go.transform.SetParent(dialogsRoot, false);

		T dialog = go.GetComponent<T>();
		dialogs.Add(dialog.GetDialogId(), dialog);

		return dialog;
	}

	public void CloseDialog(string dialogId)
	{
		if(dialogId == null) return;
		if(dialogs.ContainsKey(dialogId))
		{
			GameObject.Destroy(dialogs[dialogId].gameObject);
			dialogs.Remove(dialogId);
		}
	}
}
