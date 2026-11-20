package io.appmetrica.analytics.screenshot.impl;

import android.app.Activity;
import com.scanflow.datacapture.barinternal.io.appmetrica.analytics.screenshot.impl.d$$ExternalSyntheticApiModelOutline0;
import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.d, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0790d implements P {
    public final ClientContext a;
    public final Q b;
    public volatile C0796j c;
    public final Lazy d = LazyKt.lazy(new C0787a(this));

    public C0790d(ClientContext clientContext, Q q) {
        this.a = clientContext;
        this.b = q;
    }

    public static final Activity.ScreenCaptureCallback d(C0790d c0790d) {
        return d$$ExternalSyntheticApiModelOutline0.m(c0790d.d.getValue());
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a(C0799m c0799m) {
        this.c = c0799m != null ? c0799m.a : null;
    }

    public final String b() {
        return "AndroidApiScreenshotCaptor";
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a() {
        if (AndroidUtils.isApiAchieved(34)) {
            this.a.getActivityLifecycleRegistry().registerListener(new C0789c(this), ActivityEvent.STARTED, ActivityEvent.STOPPED);
        }
    }
}
