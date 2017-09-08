using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PickupController : MonoBehaviour {

    private static int count = 0;

	// Use this for initialization
	private void Start () {
        count++;
	}

    public static int GetCount()
    {
        return count;
    }

    public static void ResetCount(int num)
    {
        count = num;
    }
}
