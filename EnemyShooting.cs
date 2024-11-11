using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    /*public GameObject bulletPrefab; // Prefab của đạn*/
    /*[SerializeField] private Transform spawnPoint;    // Vị trí spawn của đạn*/
    [SerializeField] private float shootInterval = 3f; // Thời gian delay giữa các phát bắn
    /*[SerializeField] private float bulletSpeed = 10f;  // Tốc độ di chuyển của đạn*/
    private bool isFacingright = true;
    [SerializeField] private GameObject bombPrefap;
    // Start is called before the first frame update
    void Start()
    {
        // Bắt đầu coroutine bắn đạn mỗi 3 giây
        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // Đợi 3 giây
            Shoot();
        }
    }

    private void Shoot()
    {
        //vi tri tao ra vien dan
        Vector2 spawnPosition = transform.position;
        // van toc vien dan
        float bombspeed = 10;
        //ham kiem tra
        if (isFacingright)
        {
            spawnPosition += new Vector2(1, 0);
            bombspeed = 10f;
        }
        else
        {
            spawnPosition += new Vector2(-1, 0);
            bombspeed = -10f;
        }
        GameObject bomb = Instantiate(bombPrefap,
                                            spawnPosition, Quaternion.identity);
        //lay component bomb
        Bullet bombComonent = bomb.GetComponent<Bullet>();
        // cai dat van toc cho vien dan
        bombComonent.SetSpeed(bombspeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
