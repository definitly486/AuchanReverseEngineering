package androidx.lifecycle;

import android.annotation.SuppressLint;
import com.scanflow.datacapture.barinternal.androidx.arch.core.executor.ArchTaskExecutor;

/* JADX INFO: compiled from: LifecycleRegistry.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class LifecycleRegistry_androidKt {
    @SuppressLint({"RestrictedApi"})
    public static final boolean isMainThread() {
        return ArchTaskExecutor.getInstance().isMainThread();
    }
}
