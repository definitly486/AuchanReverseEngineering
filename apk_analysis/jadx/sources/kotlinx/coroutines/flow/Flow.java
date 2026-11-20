package kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: Flow.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface Flow<T> {
    Object collect(FlowCollector<? super T> flowCollector, Continuation<? super Unit> continuation);
}
