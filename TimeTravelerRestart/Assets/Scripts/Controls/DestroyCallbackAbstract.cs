using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//此类用于bullet等OnDestroy时，回调继承此类的父Object的ExecuteOnCallerDestroy方法，从而完成清除等功能
public class DestroyCallbackAbstract : MonoBehaviour {
    public virtual void ExecuteOnCallerDestroy() {

    }
}
