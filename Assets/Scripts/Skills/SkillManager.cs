using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject goBullet;

    private bool isSkillActive = false;
    public GameObject skill1;
    public GameObject skill2;

    private float timerForSkill2 = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(UseSkillFor10Seconds());
        }
        if (Input.GetKeyDown(KeyCode.E) && !isSkillActive && timerForSkill2 >= 60)
        {
            UseSkill_2();
            StartCoroutine(RevertScaleAfter10Seconds());
            timerForSkill2 = 0f;
        }
        timerForSkill2 += Time.deltaTime;
    }

    public void UseSkill_1()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        GameObject bullet = Instantiate(goBullet, transform.position, Quaternion.identity);

        Vector3 direction = (mousePosition - transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * 30;

        Destroy(bullet, 3f);
    }

    private IEnumerator UseSkillFor10Seconds()
    {
        float duration = 10f;
        float interval = 0.5f;

        while (duration > 0)
        {
            UseSkill_1();
            yield return new WaitForSeconds(interval);
            duration -= interval;
        }
    }

    public void UseSkill_2()
    {
        GameObject.Find("Player").transform.localScale = new Vector3(4, 4, 4);
        GameObject.Find("Player").transform.GetComponent<PlayerHealth>().currentHealth = 10000;
        isSkillActive = true;
    }

    private IEnumerator RevertScaleAfter10Seconds()
    {
        yield return new WaitForSeconds(10f);

        GameObject.Find("Player").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Player").transform.GetComponent<PlayerHealth>().currentHealth = 100;
        isSkillActive = false;
    }
}
