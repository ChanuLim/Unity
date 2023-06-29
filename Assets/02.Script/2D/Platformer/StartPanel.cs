using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    void Start()
    {
        Panel.SetActive(false);
        if(GameManager.instance.isFirst) StartCoroutine(Startscene());
    }

    // Update is called once per frame
    void Update()
    {
        destory();
    }
    IEnumerator Startscene()
    {
        yield return new WaitForSeconds(3.0f);
        Panel.SetActive(true);
    }
    void destory() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&GameManager.instance.isFirst)
        {
            GameManager.instance.isFirst = false;
            Destroy(gameObject);
            Destroy(Panel);
        }
    }
}
