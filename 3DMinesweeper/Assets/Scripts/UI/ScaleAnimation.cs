using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class ScaleAnimation
{
    /// <summary>
    /// Sets object scale to 0 then scales to full size using lean + easeOutBack animation.
    /// </summary>
    /// <param name="gameObject">GameObject to scale</param>
    /// <param name="duration">Duration of animation</param>
    /// <param name="endAction">Action to perform at end of animation</param>
    public static LTDescr StartOpen(GameObject gameObject, float duration, Action endAction = null)
    {
        gameObject.SetActive(true);

        // Vector3 is needed otherwise images do not get shown
        gameObject.transform.localScale = Vector3.zero;
        if (endAction != null)
        {
            return gameObject.transform.LeanScale(Vector3.one, duration).setEaseOutBack().setOnComplete(endAction);
        }
        else
        {
            return gameObject.transform.LeanScale(Vector3.one, duration).setEaseOutBack();
        }
    }

    /// <summary>
    /// Scales object to 0 using lean + setEaseInBack animation.
    /// </summary>
    /// <param name="gameObject">GameObject to scale</param>
    /// <param name="duration">Duration of animation</param>
    /// <param name="endAction">Action to perform at end of animation</param>
    public static LTDescr StartClose(GameObject gameObject, float duration, Action endAction = null)
    {
        if (endAction != null)
        {
            return gameObject.transform.LeanScale(Vector2.zero, duration).setEaseInBack().setOnComplete(endAction);
        }
        else
        {
            return gameObject.transform.LeanScale(Vector2.zero, duration).setEaseInBack().setIgnoreTimeScale(true);
        }
    }
}
