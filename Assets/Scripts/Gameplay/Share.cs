using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using System.IO;

public class Share : MonoBehaviour
{

    private string message;

    public ScoreController score;
    // public TokenController token;

    public void ClickShareButton(){


        string enemyScore = score.getScoreCount.ToString();
        string tokenScore = "10";

        message = "Congratulations! You scored score " + enemyScore + " and a token score of " + tokenScore;

        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
	    yield return new WaitForEndOfFrame();

	    Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	    ss.ReadPixels( new Rect(0, 0, Screen.width, Screen.height), 0, 0);
	    ss.Apply();

	    string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png");
	    File.WriteAllBytes(filePath, ss.EncodeToPNG());

	// To avoid memory leaks
	    Destroy(ss);

	    new NativeShare().AddFile(filePath).SetSubject("SSADHomies").SetText(message).SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget)).Share();
    }
}