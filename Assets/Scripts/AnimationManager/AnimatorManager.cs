using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

    public Animator animator;
    public List<AnimatorSetup> animatorSetups;

    public enum AnimatorState {
        Idle,
        Run,
        Dead
    }

    public void Play(AnimatorState state, float currentSpeedFactor = 1f) {
        foreach (var animation in animatorSetups) {
            if (animation.animatorState == state) {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Play(AnimatorState.Run);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Play(AnimatorState.Dead);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Play(AnimatorState.Idle);
        }
    }
}

        [System.Serializable]
public class AnimatorSetup {
    public AnimatorManager.AnimatorState animatorState;
    public string trigger;
    public float speed = 1f;
}
