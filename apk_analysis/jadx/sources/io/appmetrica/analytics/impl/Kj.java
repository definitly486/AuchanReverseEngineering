package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.profile.UserProfile;

/* JADX INFO: loaded from: classes3.dex */
public final class Kj implements InterfaceC0409lb {
    public final /* synthetic */ UserProfile a;

    public Kj(UserProfile userProfile) {
        this.a = userProfile;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportUserProfile(this.a);
    }
}
