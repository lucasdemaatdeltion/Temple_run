using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIstuff : MonoBehaviour {

    public GameObject player;
    public GameObject pressLeftRight;
    public Text pointText;
    public int curPoints;

    void Update() {

        Tutorial();
        PointSystem();
    }
    void Tutorial() {

        if (player.GetComponent<Movement>().uiTutorial == true) {
            pressLeftRight.SetActive(true);
        } else {
            pressLeftRight.SetActive(false);
        }
    }
    void PointSystem() {
        curPoints ++;
        pointText.GetComponent<Text>().text = "Points: " + curPoints;
    }
}
