package io.appmetrica.analytics.screenshot.impl;

import android.app.Activity;
import io.appmetrica.analytics.screenshot.impl.C0787a;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.a, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0787a extends Lambda implements Function0 {
    public final /* synthetic */ C0790d a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0787a(C0790d c0790d) {
        super(0);
        this.a = c0790d;
    }

    public static final void a(C0790d c0790d) {
        ((C0809x) c0790d.b).a("AndroidApiScreenshotCaptor");
    }

    @Override // kotlin.jvm.functions.Function0
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Activity.ScreenCaptureCallback invoke() {
        final C0790d c0790d = this.a;
        return new Activity.ScreenCaptureCallback() { // from class: com.scanflow.datacapture.barinternal.io.appmetrica.analytics.screenshot.impl.a$$ExternalSyntheticLambda0
            @Override // android.app.Activity.ScreenCaptureCallback
            public final void onScreenCaptured() {
                C0787a.a(c0790d);
            }
        };
    }
}
