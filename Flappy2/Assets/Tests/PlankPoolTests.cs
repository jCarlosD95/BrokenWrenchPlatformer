#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

/* Implemented by: Douglas Ott */

public class PlankPoolTests {

	[UnityTest]
	public IEnumerator _Instantiates_GameObject_From_Prefab() {
		//var plankPrefab = Resources.Load ("Tests/plank");
		var plankPrefab = Resources.Load ("Prefabs/PlankPrefab");
		//var plankSpawner = new GameObject ().AddComponent<plankPool> ();
		//plankSpawner.Construct (plankPrefab);

		yield return null;

		var spawnedPlank = GameObject.FindWithTag ("Plank");
		var prefabOfTheSpawnedPlank = PrefabUtility.GetPrefabParent (spawnedPlank);

		Assert.AreEqual (plankPrefab, prefabOfTheSpawnedPlank);
	}

	[UnityTest]
	public IEnumerator _Instantiates_GameObject_At_Random_Position_On_YAxis() {

		//var plankSpawner = new GameObject ().AddComponent<plankPool> ();

		yield return null;

		//var spawnedPlank = GameObject.FindWithTag ("Plank");
		//var prefabOfTheSpawnedPlank = PrefabUtility.GetPrefabParent (spawnedPlank);
		Assert.IsTrue (plankPool.plankIsInRange);
	}


	[TearDown]
	public void AfterEveryTest() {
		foreach (var gameObject in GameObject.FindGameObjectsWithTag("Plank"))
			Object.Destroy (gameObject);
	}

	/*
	[Test]
	public void PlankPoolTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator PlankPoolTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
	*/
}

#endif