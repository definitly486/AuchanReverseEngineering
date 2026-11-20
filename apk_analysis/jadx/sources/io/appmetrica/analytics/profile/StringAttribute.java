package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0499on;
import io.appmetrica.analytics.impl.C0525pn;
import io.appmetrica.analytics.impl.C0575rl;
import io.appmetrica.analytics.impl.Cdo;
import io.appmetrica.analytics.impl.InterfaceC0686w2;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.J4;
import io.appmetrica.analytics.impl.Ko;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.impl.Oi;

/* JADX INFO: loaded from: classes3.dex */
public class StringAttribute {
    private final Cdo a;
    private final L6 b;

    StringAttribute(String str, C0499on c0499on, Ko ko, InterfaceC0686w2 interfaceC0686w2) {
        this.b = new L6(str, ko, interfaceC0686w2);
        this.a = c0499on;
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValue(String str) {
        L6 l6 = this.b;
        return new UserProfileUpdate<>(new C0525pn(l6.c, str, this.a, l6.a, new J4(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueIfUndefined(String str) {
        L6 l6 = this.b;
        return new UserProfileUpdate<>(new C0525pn(l6.c, str, this.a, l6.a, new C0575rl(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueReset() {
        L6 l6 = this.b;
        return new UserProfileUpdate<>(new Oi(0, l6.c, l6.a, l6.b));
    }
}
