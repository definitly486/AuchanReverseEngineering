package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0375k3;
import io.appmetrica.analytics.impl.C0575rl;
import io.appmetrica.analytics.impl.InterfaceC0686w2;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.J4;
import io.appmetrica.analytics.impl.Ko;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.impl.Oi;

/* JADX INFO: loaded from: classes3.dex */
public class BooleanAttribute {
    private final L6 a;

    BooleanAttribute(String str, Ko ko, InterfaceC0686w2 interfaceC0686w2) {
        this.a = new L6(str, ko, interfaceC0686w2);
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValue(boolean z) {
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new C0375k3(l6.c, z, l6.a, new J4(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueIfUndefined(boolean z) {
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new C0375k3(l6.c, z, l6.a, new C0575rl(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueReset() {
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new Oi(3, l6.c, l6.a, l6.b));
    }
}
