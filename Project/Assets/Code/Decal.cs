using System.Collections;
using UnityEngine;

public class Decal : MonoBehaviour
{
	[SerializeField] private float despawnTime;

    IEnumerator Start()
    {
		yield return new WaitForSeconds(despawnTime);
		Destroy(gameObject);
    }
}
