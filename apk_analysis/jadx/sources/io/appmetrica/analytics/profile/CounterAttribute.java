package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0178cc;
import io.appmetrica.analytics.impl.C0275g6;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.impl.Mb;

/* JADX INFO: loaded from: classes3.dex */
public final class CounterAttribute {
    private final L6 a;

    CounterAttribute(String str, Mb mb, C0178cc c0178cc) {
        this.a = new L6(str, mb, c0178cc);
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withDelta(double d) {
        return new UserProfileUpdate<>(new C0275g6(this.a.c, d));
    }
}
