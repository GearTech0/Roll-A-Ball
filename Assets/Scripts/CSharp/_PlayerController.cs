using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class _PlayerController : MonoBehaviour {

    // Check every frame for player input
    // 
    public float spd;
    public Text count_text;
    public Text win_text;
    public Text timer_text;

    private Rigidbody playerRb;
    private int count = 0;
    private int total;

    private int ms = 0;
    private int s = 0;
    private int min = 0;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        total = _PickupController.GetCount();
        SetCountText();
        SetTimerText();
        win_text.text = "";
        InvokeRepeating("SetTimerText", 0, 1);
    }

    private void Update()
    {
        if (total != _PickupController.GetCount())
        {
            total = _PickupController.GetCount();
            SetCountText();
        }


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
        else if(other.gameObject.CompareTag("reset_plane"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            _PickupController.ResetCount(0);
        }
    }

    private void SetCountText()
    {
        count_text.text = "Count: " + count.ToString() + " / " + total;
        if(count >= total)
        {
            win_text.text = "YOU WIN!";
        }
    }

    private void SetTimerText()
    {
        s++;
        if(s >= 60)
        {
            s = 0;
            min++;
        }
        timer_text.text = min + ":" + s;
    }
}
