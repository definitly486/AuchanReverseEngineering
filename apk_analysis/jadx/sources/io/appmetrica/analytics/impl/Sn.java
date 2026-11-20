package io.appmetrica.analytics.impl;

import android.os.Looper;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Sn implements Un {
    @Override // io.appmetrica.analytics.impl.Un
    public final Thread a() {
        return Looper.getMainLooper().getThread();
    }

    @Override // io.appmetrica.analytics.impl.Un
    public final StackTraceElement[] b() {
        return null;
    }

    @Override // io.appmetrica.analytics.impl.Un
    public final Map c() {
        return Thread.getAllStackTraces();
    }
}
