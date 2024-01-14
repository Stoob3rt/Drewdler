using UnityEngine;
using PrimeTween;
using HutongGames.PlayMaker.TweenEnums;

public class MenuTween : MonoBehaviour
{

    void Start()
    {
       // Tween.EulerAngles(transform, Vector3.zero, new Vector3(0, 0, 360), 1, Ease.Linear, -1);
        Tween.Scale(transform, endValue: new Vector3(x: 1f, y: 1.01f, z: 1f), duration: 1.5f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
    }
}