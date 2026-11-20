package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.profile.UserProfile;

/* JADX INFO: loaded from: classes3.dex */
public final class W0 implements Runnable {
    public final /* synthetic */ UserProfile a;
    public final /* synthetic */ C0659v1 b;

    public W0(C0659v1 c0659v1, UserProfile userProfile) {
        this.b = c0659v1;
        this.a = userProfile;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportUserProfile(this.a);
    }
}
