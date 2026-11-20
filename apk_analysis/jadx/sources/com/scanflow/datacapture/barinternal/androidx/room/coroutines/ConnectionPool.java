package com.scanflow.datacapture.barinternal.androidx.room.coroutines;

import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function2;

/* JADX INFO: compiled from: ConnectionPool.kt */
/* JADX INFO: loaded from: classes.dex */
public interface ConnectionPool extends AutoCloseable {
    @Override // java.lang.AutoCloseable
    void close();

    Object useConnection(boolean z, Function2 function2, Continuation continuation);
}
