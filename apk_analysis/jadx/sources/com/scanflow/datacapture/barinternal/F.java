package com.scanflow.datacapture.barinternal;

import androidx.camera.core.Camera;
import androidx.camera.core.CameraControl;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DelayKt;
import java.util.Arrays;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.Boxing;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.StringCompanionObject;

/* JADX INFO: loaded from: classes3.dex */
public final class F extends SuspendLambda implements Function2 {
    public int a;
    public final /* synthetic */ M b;
    public final /* synthetic */ Camera c;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public F(M m, Camera camera, Continuation continuation) {
        super(2, continuation);
        this.b = m;
        this.c = camera;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        return new F(this.b, this.c, continuation);
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return new F(this.b, this.c, (Continuation) obj2).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        Camera camera;
        CameraControl cameraControl;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i = this.a;
        if (i == 0) {
            ResultKt.throwOnFailure(obj);
            this.a = 1;
            if (DelayKt.delay(2000L, this) == coroutine_suspended) {
                return coroutine_suspended;
            }
        } else {
            if (i != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
        }
        float f = 1.0f;
        for (int i2 = 1; i2 < 11; i2++) {
            StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
            String str = String.format("%.2f", Arrays.copyOf(new Object[]{Boxing.boxFloat(f - 0.1f)}, 1));
            Intrinsics.checkNotNullExpressionValue(str, "format(...)");
            f = Float.parseFloat(str);
            if (f > this.b.o && (camera = this.c) != null && (cameraControl = camera.getCameraControl()) != null) {
                cameraControl.setLinearZoom(f);
            }
            if (i2 == 10) {
                this.b.h = false;
            }
        }
        return Unit.INSTANCE;
    }
}
