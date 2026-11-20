package androidx.work.impl;

import android.os.Handler;
import android.os.Looper;
import androidx.work.RunnableScheduler;
import com.scanflow.datacapture.barinternal.androidx.core.os.HandlerCompat;

/* JADX INFO: loaded from: classes.dex */
public class DefaultRunnableScheduler implements RunnableScheduler {
    private final Handler mHandler = HandlerCompat.createAsync(Looper.getMainLooper());

    public Handler getHandler() {
        return this.mHandler;
    }

    @Override // androidx.work.RunnableScheduler
    public void scheduleWithDelay(long j, Runnable runnable) {
        this.mHandler.postDelayed(runnable, j);
    }

    @Override // androidx.work.RunnableScheduler
    public void cancel(Runnable runnable) {
        this.mHandler.removeCallbacks(runnable);
    }
}
