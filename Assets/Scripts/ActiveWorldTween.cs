using UnityEngine;
using PrimeTween;


public class ActiveWorldTween : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
         Tween.Scale(transform, endValue: new Vector3(x: .41f, y: .41f, z: .41f), duration: 1f, Ease.OutSine, cycles: -1, CycleMode.Yoyo);
        // Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);
    }


}

