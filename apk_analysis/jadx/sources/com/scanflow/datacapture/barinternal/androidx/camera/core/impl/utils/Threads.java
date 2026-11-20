package com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils;

import android.os.Handler;
import android.os.Looper;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;

/* JADX INFO: loaded from: classes.dex */
public abstract class Threads {
    public static boolean isMainThread() {
        return Looper.getMainLooper().getThread() == Thread.currentThread();
    }

    public static void checkMainThread() {
        Preconditions.checkState(isMainThread(), "Not in application's main thread");
    }

    public static void runOnMain(Runnable runnable) {
        if (isMainThread()) {
            runnable.run();
        } else {
            Preconditions.checkState(getMainHandler().post(runnable), "Unable to post to main thread");
        }
    }

    private static Handler getMainHandler() {
        return new Handler(Looper.getMainLooper());
    }
}
