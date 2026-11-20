package com.scanflow.datacapture.utils;

import android.util.Log;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ScanflowLog {
    public static final ScanflowLog INSTANCE = new ScanflowLog();
    private static final String PREFIX = "ScanflowLog:";
    private static boolean loggingEnabled;

    private ScanflowLog() {
    }

    public final void d(String tag, String message) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(message, "message");
        if (loggingEnabled) {
            Log.d("ScanflowLog: " + tag, message);
        }
    }

    public final void e(String tag, String message) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(message, "message");
        if (loggingEnabled) {
            Log.e("ScanflowLog: " + tag, message);
        }
    }

    public final void enable(boolean z) {
        loggingEnabled = z;
    }

    public final void i(String tag, String message) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(message, "message");
        if (loggingEnabled) {
            Log.i("ScanflowLog: " + tag, message);
        }
    }

    public final boolean isLogEnabled() {
        return loggingEnabled;
    }

    public final void v(String tag, String message) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(message, "message");
        if (loggingEnabled) {
            Log.v("ScanflowLog: " + tag, message);
        }
    }

    public final void w(String tag, String message) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(message, "message");
        if (loggingEnabled) {
            Log.w("ScanflowLog: " + tag, message);
        }
    }
}
