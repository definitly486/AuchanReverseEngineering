package com.scanflow.datacapture.barinternal;

import androidx.camera.core.Camera;
import androidx.camera.core.CameraControl;
import androidx.lifecycle.CoroutineLiveDataKt;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DelayKt;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import java.util.Arrays;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.Boxing;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$FloatRef;
import kotlin.jvm.internal.StringCompanionObject;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: loaded from: classes3.dex */
public final class G extends SuspendLambda implements Function2 {
    public int a;
    public final /* synthetic */ Ref$FloatRef b;
    public final /* synthetic */ Float c;
    public final /* synthetic */ M d;
    public final /* synthetic */ Camera e;
    public final /* synthetic */ Analyzer.OnAnalyzeListener f;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public G(Ref$FloatRef ref$FloatRef, Float f, M m, Camera camera, Analyzer.OnAnalyzeListener onAnalyzeListener, Continuation continuation) {
        super(2, continuation);
        this.b = ref$FloatRef;
        this.c = f;
        this.d = m;
        this.e = camera;
        this.f = onAnalyzeListener;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        return new G(this.b, this.c, this.d, this.e, this.f, continuation);
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return ((G) create((CoroutineScope) obj, (Continuation) obj2)).invokeSuspend(Unit.INSTANCE);
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
            if (DelayKt.delay(CoroutineLiveDataKt.DEFAULT_TIMEOUT, this) == coroutine_suspended) {
                return coroutine_suspended;
            }
        } else {
            if (i != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
        }
        for (int i2 = 1; i2 < 101; i2++) {
            this.b.element -= 0.01f;
            StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
            String str = String.format("%.2f", Arrays.copyOf(new Object[]{Boxing.boxFloat(this.c.floatValue() + this.b.element)}, 1));
            Intrinsics.checkNotNullExpressionValue(str, "format(...)");
            float f = Float.parseFloat(str);
            if (f > this.d.o && (camera = this.e) != null && (cameraControl = camera.getCameraControl()) != null) {
                cameraControl.setLinearZoom(f);
            }
            if (i2 == 100) {
                this.d.h = false;
                Analyzer.OnAnalyzeListener onAnalyzeListener = this.f;
                if (onAnalyzeListener != null) {
                    onAnalyzeListener.OnOneTouchCallbackCompleted();
                }
            }
        }
        return Unit.INSTANCE;
    }
}
