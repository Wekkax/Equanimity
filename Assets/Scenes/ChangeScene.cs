using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<Fade>();

    }

    public IEnumerator _ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("s02_cueva");
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.gameObject.tag == "camera")
        {
            StartCoroutine(_ChangeScene());
        }
    }

}
