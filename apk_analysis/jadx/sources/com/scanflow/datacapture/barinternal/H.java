package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineScopeKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Deferred;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import com.scanflow.datacapture.utils.ScanflowLog;
import java.util.ArrayList;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class H extends SuspendLambda implements Function2 {
    public int a;
    public final /* synthetic */ M b;
    public final /* synthetic */ Analyzer.OnAnalyzeListener c;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public H(M m, Analyzer.OnAnalyzeListener onAnalyzeListener, Continuation continuation) {
        super(2, continuation);
        this.b = m;
        this.c = onAnalyzeListener;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        return new H(this.b, this.c, continuation);
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return new H(this.b, this.c, (Continuation) obj2).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i = this.a;
        if (i == 0) {
            ResultKt.throwOnFailure(obj);
            M m = this.b;
            ArrayList croppedBitmapList = m.Q;
            Analyzer.OnAnalyzeListener listener = this.c;
            Intrinsics.checkNotNullParameter(croppedBitmapList, "croppedBitmapList");
            Intrinsics.checkNotNullParameter(listener, "listener");
            Deferred deferredAsync$default = BuildersKt__Builders_commonKt.async$default(CoroutineScopeKt.CoroutineScope(Dispatchers.getIO()), null, null, new K(croppedBitmapList, m, listener, null), 3, null);
            this.a = 1;
            obj = deferredAsync$default.await(this);
            if (obj == coroutine_suspended) {
                return coroutine_suspended;
            }
        } else {
            if (i != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
        }
        ScanflowLog.INSTANCE.v("resultOne", String.valueOf(((ArrayList) obj).size()));
        return Unit.INSTANCE;
    }
}
