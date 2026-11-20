package androidx.lifecycle.viewmodel.internal;

import com.scanflow.datacapture.barinternal.kotlin.NotImplementedError;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.SupervisorKt;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.EmptyCoroutineContext;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: CloseableCoroutineScope.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CloseableCoroutineScopeKt {
    public static final String VIEW_MODEL_SCOPE_KEY = "androidx.lifecycle.viewmodel.internal.ViewModelCoroutineScope.JOB_KEY";

    public static final CloseableCoroutineScope createViewModelScope() {
        CoroutineContext immediate;
        try {
            immediate = Dispatchers.getMain().getImmediate();
        } catch (NotImplementedError unused) {
            immediate = EmptyCoroutineContext.INSTANCE;
        } catch (IllegalStateException unused2) {
            immediate = EmptyCoroutineContext.INSTANCE;
        }
        return new CloseableCoroutineScope(immediate.plus(SupervisorKt.SupervisorJob$default(null, 1, null)));
    }

    public static final CloseableCoroutineScope asCloseable(CoroutineScope coroutineScope) {
        Intrinsics.checkNotNullParameter(coroutineScope, "<this>");
        return new CloseableCoroutineScope(coroutineScope);
    }
}
