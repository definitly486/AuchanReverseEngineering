package com.scanflow.datacapture.barinternal.kotlinx.coroutines.android;

import android.os.Looper;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.MainCoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.MainDispatcherFactory;
import java.util.List;

/* JADX INFO: compiled from: HandlerDispatcher.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class AndroidDispatcherFactory implements MainDispatcherFactory {
    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.MainDispatcherFactory
    public MainCoroutineDispatcher createDispatcher(List list) {
        Looper mainLooper = Looper.getMainLooper();
        if (mainLooper == null) {
            throw new IllegalStateException("The main looper is not available");
        }
        return new HandlerContext(HandlerDispatcherKt.asHandler(mainLooper, true), null, 2, null);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.MainDispatcherFactory
    public String hintOnError() {
        return "For tests Dispatchers.setMain from kotlinx-coroutines-test module can be used";
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.MainDispatcherFactory
    public int getLoadPriority() {
        return 1073741823;
    }
}
