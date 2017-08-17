using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.SpriteAssetUtilities;

public class ScoreController : MonoBehaviour {

    public TextMeshPro scoreText;
    public float score = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(float a)
    {
        score += a;
        scoreText.text = score.ToString();
    }
}
