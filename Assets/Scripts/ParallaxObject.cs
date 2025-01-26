using UnityEngine;

public class ParallaxObject : SimpleMonster
{
    public float value;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        rigidBody.linearVelocity += Vector2.up * PlayerBubble.Instance.CurrentUpwardSpeed * value;
    }
}
