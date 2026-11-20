package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.MainCoroutineDispatcher;
import java.util.List;

/* JADX INFO: compiled from: MainDispatcherFactory.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface MainDispatcherFactory {
    MainCoroutineDispatcher createDispatcher(List list);

    int getLoadPriority();

    String hintOnError();
}
