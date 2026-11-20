package io.appmetrica.analytics.screenshot.impl;

import android.app.Activity;
import android.provider.MediaStore;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.u, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0806u implements ActivityLifecycleListener {
    public final /* synthetic */ C0807v a;

    public C0806u(C0807v c0807v) {
        this.a = c0807v;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
    public final void onEvent(Activity activity, ActivityEvent activityEvent) {
        int i = AbstractC0805t.a[activityEvent.ordinal()];
        try {
            if (i != 1) {
                if (i != 2) {
                    return;
                }
                this.a.a.getContext().getContentResolver().unregisterContentObserver(this.a.d);
            } else {
                C0797k c0797k = this.a.c;
                if (c0797k == null || !c0797k.a) {
                    return;
                }
                this.a.a.getContext().getContentResolver().registerContentObserver(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, true, this.a.d);
            }
        } catch (Throwable unused) {
        }
    }
}
