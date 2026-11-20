package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlinx.coroutines.CoroutineScope;
import org.opencv.core.Mat;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.n, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0096n extends SuspendLambda implements Function2 {
    public final /* synthetic */ int a;
    public final /* synthetic */ Mat b;
    public final /* synthetic */ int c;
    public final /* synthetic */ int d;
    public final /* synthetic */ Mat e;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0096n(int i, int i2, int i3, Continuation continuation, Mat mat, Mat mat2) {
        super(2, continuation);
        this.a = i;
        this.b = mat;
        this.c = i2;
        this.d = i3;
        this.e = mat2;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        return new C0096n(this.a, this.c, this.d, continuation, this.b, this.e);
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return ((C0096n) create((CoroutineScope) obj, (Continuation) obj2)).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        ResultKt.throwOnFailure(obj);
        for (int i = 0; i < this.a; i++) {
            if (((int) this.b.get(this.c, i)[0]) == this.d) {
                this.e.put(this.c, i, 0.0d);
            }
        }
        return Unit.INSTANCE;
    }
}
