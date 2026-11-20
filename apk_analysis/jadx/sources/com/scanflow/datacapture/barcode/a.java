package com.scanflow.datacapture.barcode;

import com.scanflow.datacapture.barinternal.A;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineScopeKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Deferred;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.utils.ScanflowLog;
import java.util.ArrayList;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a extends SuspendLambda implements Function2 {
    public int a;
    public final /* synthetic */ b b;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public a(b bVar, Continuation continuation) {
        super(2, continuation);
        this.b = bVar;
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        return new a(this.b, continuation);
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return new a(this.b, (Continuation) obj2).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i = this.a;
        if (i == 0) {
            ResultKt.throwOnFailure(obj);
            b bVar = this.b;
            ArrayList croppedBitmapList = bVar.l;
            Intrinsics.checkNotNullParameter(croppedBitmapList, "croppedBitmapList");
            Deferred deferredAsync$default = BuildersKt__Builders_commonKt.async$default(CoroutineScopeKt.CoroutineScope(Dispatchers.getIO()), null, null, new A(croppedBitmapList, bVar, null), 3, null);
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
