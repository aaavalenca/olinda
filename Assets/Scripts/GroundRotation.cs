using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    private Vector3 _tmp;
    public bool up = false;
    private AudioSource _as;
    
    void Start() {
        _tmp = transform.rotation.eulerAngles;
        StartCoroutine("UpAndDown");
        _as = GetComponent<AudioSource>();
    }

    IEnumerator UpAndDown()
    {
        yield return new WaitForSeconds(Random.Range(25, 35));
        up = true;
        _as.PlayOneShot(_as.clip);
        for (float r = 0f; r <= 15f; r += 0.05f)
        {
            _tmp.z = r;
            transform.eulerAngles = _tmp;
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(2, 5));
        up = false;
        _as.Stop();
        for (float r = 15f; r >= 0f; r -= 0.05f)
        {
            _tmp.z = r;
            transform.eulerAngles = _tmp;
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(4, 7));
        StartCoroutine("UpAndDown");
    }
}
