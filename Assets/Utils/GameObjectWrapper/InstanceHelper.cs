using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHelper<TSpecific> where TSpecific : AccessScript<TSpecific>
{
	public GameObject GameObject;
	public TSpecific AccessScript;

	private string _resourceName;
	public InstanceHelper(string resourceName)
	{
		_resourceName = resourceName;
		InitializePrefab();
		InitializeAccessScript(GameObject);
    }

	public void InitializePrefab()
	{
		var prefab = Resources.Load(_resourceName);
		var gameObject = GameObject.Instantiate(prefab);
		this.GameObject = gameObject as GameObject;
	}

	public void InitializeAccessScript(GameObject gameObject)
	{
		var accessScript = gameObject.GetComponent<TSpecific>();
		if (accessScript is null) throw new System.Exception($"Tried to load {_resourceName} but the resource was null.");

		this.AccessScript = accessScript;
	}

	public void AddMutualReferences()
	{
		this.AccessScript.Wrapper = this;
	}
}
