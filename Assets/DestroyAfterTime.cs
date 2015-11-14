//Destroys game object after given time. If you don't understand this and need the comment,
//give up on making games. 

using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine("Destroy", time);
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject, time);
    }
}
