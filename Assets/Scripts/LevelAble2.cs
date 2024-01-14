using UnityEngine;
using PrimeTween;
using HutongGames.PlayMaker.TweenEnums;

public class LevelAble3 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
         Tween.Scale(transform, endValue: new Vector3(x: .24f, y: 0.26f, z: .24f), duration: 2f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
        // Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);
    }


    // Update is called once per frame

}

