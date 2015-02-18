using UnityEngine;
using System.Collections;

public class blueCheck : MonoBehaviour {

	public AudioSource blueSound;
	public AudioSource blueSFX1;
	public AudioSource blueSFX2;
	public AudioSource blueSFX3;
	public Camera theCamera;
	private bool blueExecute = false;
	// Use this for initialization
	void Start () {
	
		theCamera.clearFlags = CameraClearFlags.SolidColor;

	}
	
	// Update is called once per frame
	void Update () {
		if (pullTweets.blue && !blueExecute) {
						blueAction ();
				}
		if (!pullTweets.blue) {
			//blueSound.Stop ();
			theCamera.backgroundColor = Color.black;
			blueExecute = false;
				}
	}

	void blueAction() {
		/*if (pullTweets.blue && !blueSound.isPlaying) {
			blueSound.Play();
			blueSound.loop = true;
			theCamera.backgroundColor = Color.blue;
		}*/

			theCamera.backgroundColor = Color.blue;
			for (int i = 0; i  < pullTweets.soundSequence.Length; i++) {
			if (pullTweets.soundSequence [i] == 1){blueSFX1.Play ();}
			if (pullTweets.soundSequence [i] == 2){blueSFX2.Play ();}
			if (pullTweets.soundSequence [i] == 3){blueSFX3.Play ();}
					
		}

		blueExecute = true;
	}
}
