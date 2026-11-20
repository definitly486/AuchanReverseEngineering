package com.scanflow.datacapture.barinternal;

import android.animation.ObjectAnimator;
import android.animation.ValueAnimator;
import android.graphics.RectF;
import android.os.Handler;
import android.os.Looper;
import android.view.animation.LinearInterpolator;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.ui.ar.ArObject;
import com.scanflow.ui.ar.ArObjectTracker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class w extends ArObjectTracker {
    public final long a = 2000;
    public final long b = 100;
    public final Handler c = new Handler(Looper.getMainLooper());
    public ArObject d;
    public RectF e;
    public ObjectAnimator f;

    public final void a() {
        this.d = null;
        a(null);
    }

    @Override // com.scanflow.ui.ar.ArObjectTracker
    public final void processObject(ArObject arObject) {
        float[] floatArray;
        if (arObject == null) {
            if (this.e != null) {
                this.c.postDelayed(new Runnable() { // from class: com.scanflow.datacapture.barinternal.w$$ExternalSyntheticLambda0
                    @Override // java.lang.Runnable
                    public final void run() {
                        this.f$0.a();
                    }
                }, this.a);
                return;
            }
            return;
        }
        this.c.removeCallbacks(new Runnable() { // from class: com.scanflow.datacapture.barinternal.w$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.a();
            }
        });
        RectF rectF = this.e;
        if (rectF == null || (floatArray = ArraysKt.toFloatArray(new Float[]{Float.valueOf(rectF.left), Float.valueOf(rectF.top), Float.valueOf(rectF.right), Float.valueOf(rectF.bottom)})) == null) {
            RectF boundingBox = arObject.getBoundingBox();
            floatArray = ArraysKt.toFloatArray(new Float[]{Float.valueOf(boundingBox.left), Float.valueOf(boundingBox.top), Float.valueOf(boundingBox.right), Float.valueOf(boundingBox.bottom)});
        }
        RectF boundingBox2 = arObject.getBoundingBox();
        float[] floatArray2 = ArraysKt.toFloatArray(new Float[]{Float.valueOf(boundingBox2.left), Float.valueOf(boundingBox2.top), Float.valueOf(boundingBox2.right), Float.valueOf(boundingBox2.bottom)});
        this.d = arObject;
        ObjectAnimator objectAnimator = this.f;
        if (objectAnimator != null) {
            objectAnimator.cancel();
        }
        ObjectAnimator objectAnimatorOfMultiFloat = ObjectAnimator.ofMultiFloat(this, "boundingBox", new float[][]{floatArray, floatArray2});
        objectAnimatorOfMultiFloat.setDuration(this.b);
        objectAnimatorOfMultiFloat.setInterpolator(new LinearInterpolator());
        objectAnimatorOfMultiFloat.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() { // from class: com.scanflow.datacapture.barinternal.w$$ExternalSyntheticLambda1
            @Override // android.animation.ValueAnimator.AnimatorUpdateListener
            public final void onAnimationUpdate(ValueAnimator valueAnimator) {
                w.a(this.f$0, valueAnimator);
            }
        });
        objectAnimatorOfMultiFloat.start();
        this.f = objectAnimatorOfMultiFloat;
    }

    public static final void a(w this$0, ValueAnimator it) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(it, "it");
        Object animatedValue = it.getAnimatedValue();
        Intrinsics.checkNotNull(animatedValue, "null cannot be cast to non-null type kotlin.FloatArray");
        this$0.a((float[]) animatedValue);
    }

    public final void a(float[] fArr) {
        RectF rectF;
        if (fArr != null) {
            rectF = new RectF();
            rectF.left = fArr[0];
            rectF.top = fArr[1];
            rectF.right = fArr[2];
            rectF.bottom = fArr[3];
        } else {
            rectF = null;
        }
        this.e = rectF;
        ArObject arObject = this.d;
        if (arObject != null) {
            String strComponent1 = arObject.component1();
            RectF rectF2 = this.e;
            Intrinsics.checkNotNull(rectF2);
            publish(this.e != null ? new ArObject(strComponent1, rectF2, arObject.component3(), arObject.component4(), arObject.component5(), arObject.component6(), true) : null);
        }
    }
}
