package com.scanflow.datacapture.barinternal.kotlin.sequences;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import java.util.Iterator;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: SequenceBuilder.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class SequenceScope {
    public abstract Object yield(Object obj, Continuation continuation);

    public abstract Object yieldAll(Iterator it, Continuation continuation);

    public final Object yieldAll(Sequence sequence, Continuation continuation) {
        Object objYieldAll = yieldAll(sequence.iterator(), continuation);
        return objYieldAll == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objYieldAll : Unit.INSTANCE;
    }
}
