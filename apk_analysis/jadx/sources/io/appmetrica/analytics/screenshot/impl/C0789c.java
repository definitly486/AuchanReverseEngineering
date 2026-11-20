package io.appmetrica.analytics.screenshot.impl;

import android.annotation.SuppressLint;
import android.app.Activity;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.c, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0789c implements ActivityLifecycleListener {
    public final /* synthetic */ C0790d a;

    public C0789c(C0790d c0790d) {
        this.a = c0790d;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
    @SuppressLint({"MissingPermission", "NewApi"})
    public final void onEvent(Activity activity, ActivityEvent activityEvent) {
        int i = AbstractC0788b.a[activityEvent.ordinal()];
        try {
            if (i != 1) {
                if (i != 2) {
                    return;
                }
                activity.unregisterScreenCaptureCallback(C0790d.d(this.a));
            } else {
                C0796j c0796j = this.a.c;
                if (c0796j == null || !c0796j.a) {
                    return;
                }
                activity.registerScreenCaptureCallback(this.a.a.getContext().getMainExecutor(), C0790d.d(this.a));
            }
        } catch (Throwable unused) {
        }
    }
}
