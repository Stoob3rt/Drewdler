using UnityEngine;
using PrimeTween;
using HutongGames.PlayMaker.TweenEnums;

public class tweener : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
         Tween.Scale(transform, endValue: new Vector3(x: .21f, y: 0.2f, z: .21f), duration: 0.5f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
        // Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Run your code here.
            Tween.Scale(transform, endValue: new Vector3(.2f, .3f, .25f), duration: 0.1f, Ease.OutSine, cycles: 2, CycleMode.Yoyo);

        }

    }
    // Update is called once per frame

}

