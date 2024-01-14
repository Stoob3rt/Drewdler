using UnityEngine;
using PrimeTween;
using HutongGames.PlayMaker.TweenEnums;

public class Spikes : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
          Tween.Scale(transform, endValue: new Vector3(x: .35f, y: .3f, z: 0f), duration: 0.5f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
        // Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Run your code here.
            //Tween.Scale(transform, endValue: new Vector3(.7f, .3f, .7f), duration: 0.12f, Ease.OutSine, cycles: 2, CycleMode.Yoyo);
            //Tween.Position(transform, endValue: new Vector3(-5f, 1f, 0f), duration: 0.12f, Ease.OutSine, cycles: 1, CycleMode.Yoyo);
            Tween.PositionX(transform, endValue: -.1f, duration: .01f);

        }

    }
    // Update is called once per frame
    void Update()
    {
        // You can add any necessary update logic here
    }

    //    private void OnCollisionEnter(Collision collision)
    //   {
    //       if (collision.gameObject.CompareTag("Player"))
    //       {
    // Start the PrimeTween animation only when the player collides with this object

    //            Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);

    //        }
    //   }
}

