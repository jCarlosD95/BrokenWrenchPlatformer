using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/* Implemented by: Douglas */

public class CharacterTests {

	[Test]
	public void BirdTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator BirdDiedCorrectlyPasses() {
		var character = new GameObject ().AddComponent<Bird> ();

		yield return null;

		//var spawnedPlank = GameObject.FindWithTag ("Plank");
		//var prefabOfTheSpawnedPlank = PrefabUtility.GetPrefabParent (spawnedPlank);
		Assert.IsTrue (Bird.birdDiedCorrectly);
	}
}
