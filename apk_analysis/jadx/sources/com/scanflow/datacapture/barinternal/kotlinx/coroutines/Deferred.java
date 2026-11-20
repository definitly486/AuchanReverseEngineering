package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Deferred.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface Deferred extends Job {
    Object await(Continuation continuation);

    Object getCompleted();
}
