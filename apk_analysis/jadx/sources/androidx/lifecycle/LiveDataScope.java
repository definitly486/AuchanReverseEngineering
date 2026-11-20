package androidx.lifecycle;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DisposableHandle;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: CoroutineLiveData.kt */
/* JADX INFO: loaded from: classes.dex */
public interface LiveDataScope<T> {
    Object emit(T t, Continuation<? super Unit> continuation);

    Object emitSource(LiveData<T> liveData, Continuation<? super DisposableHandle> continuation);

    T getLatestValue();
}
