using UnityEngine;
using System.Collections;

public class CoroutineManager : MonoBehaviour {

    private static CoroutineManager _coroutineManager;

    public static CoroutineManager _CoroutineManager
    {
        get
        {
            return _coroutineManager;
        }
    }
	
    void Start()
    {
        if(_coroutineManager != null)
        {
            Destroy(this);
        }

        _coroutineManager = this;
    }

	public void MakeCoroutine(IEnumerator coroutine)
    {
        _coroutineManager.StartCoroutine(coroutine);
    }
}
