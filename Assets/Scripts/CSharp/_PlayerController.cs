using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _PlayerController : MonoBehaviour {

    // Check every frame for player input
    // 
    public float spd;
    public Text count_text;
    public Text win_text;

    private Rigidbody playerRb;
    private int count = 0;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        SetCountText();
        win_text.text = "";
    }

    private void FixedUpdate()
    {
        float mHor = Input.GetAxis("Horizontal");
        float mVer = Input.GetAxis("Vertical");

        Vector3 vForce = new Vector3(mHor, 0.0f, mVer);

        playerRb.AddForce(vForce * spd);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick_up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        count_text.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            win_text.text = "YOU WIN!";
        }
    }
}
