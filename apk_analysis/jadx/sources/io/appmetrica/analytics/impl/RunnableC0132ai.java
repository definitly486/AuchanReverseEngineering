package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.profile.UserProfile;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ai, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0132ai implements Runnable {
    public final /* synthetic */ UserProfile a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0132ai(C0624ti c0624ti, UserProfile userProfile) {
        this.b = c0624ti;
        this.a = userProfile;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportUserProfile(this.a);
    }
}
