package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0178cc;
import io.appmetrica.analytics.impl.C0473nn;
import io.appmetrica.analytics.impl.C0499on;
import io.appmetrica.analytics.impl.C0601sl;
import io.appmetrica.analytics.impl.C0614t8;
import io.appmetrica.analytics.impl.D4;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.J4;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public class FirstPartyDataEmailSha256Attribute {
    private final L6 a = new L6("appmetrica_1pd_email_sha256", new C0614t8(), new C0178cc(new D4(100)));
    private final C0601sl b;

    FirstPartyDataEmailSha256Attribute(C0601sl c0601sl) {
        this.b = c0601sl;
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withEmailValues(String... strArr) {
        return withEmailValues(Arrays.asList(strArr));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withEmailValues(Iterable<String> iterable) {
        String str = this.a.c;
        ArrayList arrayListA = this.b.a(iterable);
        C0499on c0499on = new C0499on(200, "First party data emails attribute", PublicLogger.getAnonymousInstance());
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new C0473nn(str, arrayListA, 10, c0499on, l6.a, new J4(l6.b)));
    }
}
