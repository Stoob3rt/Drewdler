using UnityEngine;
using PrimeTween;


public class PortalCollision : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        // Tween.Scale(transform, endValue: new Vector3(x: 1.15f, y: 0.9f, z: 1.15f), duration: 0.5f, Ease.OutSine, cycles: -1, CycleMode.Rewind);
        // Tween.Scale(transform, 1.2f, 1.1f, cycles: -1, cycleMode: CycleMode.Yoyo);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the player.
        if (collision.gameObject.CompareTag("Finish"))
        {
            // Run your code here.
            Tween.Scale(transform, endValue: new Vector3(0f, 0f, 0f), duration: 0.1f, Ease.OutSine, cycles: 1, CycleMode.Yoyo);

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

