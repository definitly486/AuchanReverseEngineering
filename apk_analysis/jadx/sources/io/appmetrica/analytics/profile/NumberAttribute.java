package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.Be;
import io.appmetrica.analytics.impl.C0178cc;
import io.appmetrica.analytics.impl.C0575rl;
import io.appmetrica.analytics.impl.D4;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.J4;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.impl.Mb;
import io.appmetrica.analytics.impl.Oi;

/* JADX INFO: loaded from: classes3.dex */
public final class NumberAttribute {
    private final L6 a;

    NumberAttribute(String str, Mb mb, C0178cc c0178cc) {
        this.a = new L6(str, mb, c0178cc);
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValue(double d) {
        return new UserProfileUpdate<>(new Be(this.a.c, d, new Mb(), new J4(new C0178cc(new D4(100)))));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueIfUndefined(double d) {
        return new UserProfileUpdate<>(new Be(this.a.c, d, new Mb(), new C0575rl(new C0178cc(new D4(100)))));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueReset() {
        return new UserProfileUpdate<>(new Oi(1, this.a.c, new Mb(), new C0178cc(new D4(100))));
    }
}
