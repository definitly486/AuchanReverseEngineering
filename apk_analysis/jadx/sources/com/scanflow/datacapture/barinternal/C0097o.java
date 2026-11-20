package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlinx.coroutines.CoroutineScope;
import org.opencv.core.Mat;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.o, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0097o extends SuspendLambda implements Function2 {
    public /* synthetic */ Object a;
    public final /* synthetic */ int b;
    public final /* synthetic */ int c;
    public final /* synthetic */ Mat d;
    public final /* synthetic */ int e;
    public final /* synthetic */ Mat f;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0097o(int i, int i2, int i3, Continuation continuation, Mat mat, Mat mat2) {
        super(2, continuation);
        this.b = i;
        this.c = i2;
        this.d = mat;
        this.e = i3;
        this.f = mat2;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        C0097o c0097o = new C0097o(this.b, this.c, this.e, continuation, this.d, this.f);
        c0097o.a = obj;
        return c0097o;
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return ((C0097o) create((CoroutineScope) obj, (Continuation) obj2)).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        ResultKt.throwOnFailure(obj);
        CoroutineScope coroutineScope = (CoroutineScope) this.a;
        for (int i = 0; i < this.b; i++) {
            BuildersKt__Builders_commonKt.launch$default(coroutineScope, Dispatchers.getDefault(), null, new C0096n(this.c, i, this.e, null, this.d, this.f), 2, null);
        }
        return Unit.INSTANCE;
    }
}
