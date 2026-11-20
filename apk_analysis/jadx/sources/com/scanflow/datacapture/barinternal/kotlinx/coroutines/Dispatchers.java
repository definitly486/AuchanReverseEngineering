package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.MainDispatcherLoader;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.scheduling.DefaultIoScheduler;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.scheduling.DefaultScheduler;

/* JADX INFO: compiled from: Dispatchers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Dispatchers {
    public static final Dispatchers INSTANCE = new Dispatchers();
    private static final CoroutineDispatcher Default = DefaultScheduler.INSTANCE;
    private static final CoroutineDispatcher Unconfined = Unconfined.INSTANCE;

    private Dispatchers() {
    }

    public static final CoroutineDispatcher getDefault() {
        return Default;
    }

    public static final MainCoroutineDispatcher getMain() {
        return MainDispatcherLoader.dispatcher;
    }

    public static final CoroutineDispatcher getIO() {
        return DefaultIoScheduler.INSTANCE;
    }
}
