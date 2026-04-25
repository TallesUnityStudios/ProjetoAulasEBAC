using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Projectille prefabProjectille; // Prefab of
    public Transform positionToShoot;
    public Transform playerSideReference;

    public float timeBetweenShoot = .3f; // Time in seconds between each shot

    private Coroutine _currentCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    private void Shoot()
    {
        var projectille = Instantiate(prefabProjectille);
        projectille.transform.position = positionToShoot.position;
        projectille.side = playerSideReference.transform.localScale.x;
    }
}
