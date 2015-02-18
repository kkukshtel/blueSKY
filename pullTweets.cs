
using UnityEngine;
using System.Collections;

public class pullTweets : MonoBehaviour {

	public string access_url;
	public string data;
	private bool connectionEstablished = false;
	public static bool blue = false;
	public static int[] soundSequence = new int[5];
	public bool checking = true;
	
	void Start () {
	
		StartCoroutine(checkForBlue());

	}

	void Update () {

		//checkForBlue(System.DateTime.Now);
		/*if (Input.GetKeyDown (KeyCode.E)) {
			blue = !blue;
		}*/
	}



	private IEnumerator pingNetwork () {

		connectionEstablished = false;
		WWW cu_get = new WWW(access_url);
		yield return cu_get;
		if(!string.IsNullOrEmpty(cu_get.error)) {
			
			Debug.Log("ERROR: " + cu_get.error);
			
		}
		else
		{
			Debug.Log("able to access gettweetsjson.php");
			data = cu_get.text;
			Debug.Log(data);
			connectionEstablished = true;
		}
		
	}

	private IEnumerator checkForBlue (){

		while (checking) {

			System.DateTime checkTime = System.DateTime.Now;

			Debug.Log ("check for blue called at " + checkTime);

			yield return StartCoroutine(pingNetwork());

			if (connectionEstablished) {

				string[] tweetTime = data.Split (" " [0]);        
				int tweetHour = int.Parse (tweetTime [0]);
				int tweetMinutes = int.Parse (tweetTime [1]);
				int tweetMonth = int.Parse (tweetTime [2]);
				int tweetDay = int.Parse (tweetTime [3]);
				int tweetYear = int.Parse (tweetTime [4]);

				//seed the random generator with the number, then multiply by three and then floor the number
				Random.seed = tweetYear;
				soundSequence[0] = Random.Range(1,3);
				Random.seed = tweetDay;
				soundSequence[1] = Random.Range(1,3);
				Random.seed = tweetMonth;
				soundSequence[2] = Random.Range(1,3);
				Random.seed = tweetMinutes;
				soundSequence[3] = Random.Range(1,3);
				Random.seed = tweetHour;
				soundSequence[4] = Random.Range(1,3);
				Debug.Log(soundSequence[0]+ "" +soundSequence[1]+ "" +soundSequence[2]+ "" +soundSequence[3]+ "" +soundSequence[4]);


				//if there was a tweet on the day the game is played
				if (checkTime.Year == tweetYear && checkTime.Month == tweetMonth && checkTime.Day == tweetDay && checkTime.Hour == tweetHour ) { 
						blue = true;
				} else { 
						blue = false;
				}
			}

			yield return new WaitForSeconds(300f);
			//Debug.Log("the time of the newest tweet is " + theTime);
		}
	}
	
}


