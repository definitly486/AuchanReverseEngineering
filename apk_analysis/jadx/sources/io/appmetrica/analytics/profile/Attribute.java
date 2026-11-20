package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0178cc;
import io.appmetrica.analytics.impl.C0499on;
import io.appmetrica.analytics.impl.C0601sl;
import io.appmetrica.analytics.impl.D4;
import io.appmetrica.analytics.impl.Dn;
import io.appmetrica.analytics.impl.Mb;
import io.appmetrica.analytics.impl.O8;
import io.appmetrica.analytics.impl.We;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class Attribute {
    public static BirthDateAttribute birthDate() {
        return new BirthDateAttribute();
    }

    public static BooleanAttribute customBoolean(String str) {
        return new BooleanAttribute(str, new Mb(), new C0178cc(new D4(100)));
    }

    public static CounterAttribute customCounter(String str) {
        return new CounterAttribute(str, new Mb(), new C0178cc(new D4(100)));
    }

    public static NumberAttribute customNumber(String str) {
        return new NumberAttribute(str, new Mb(), new C0178cc(new D4(100)));
    }

    public static StringAttribute customString(String str) {
        return new StringAttribute(str, new C0499on(200, "String attribute \"" + str + "\"", PublicLogger.getAnonymousInstance()), new Mb(), new C0178cc(new D4(100)));
    }

    public static FirstPartyDataEmailSha256Attribute emailHash() {
        return new FirstPartyDataEmailSha256Attribute(new C0601sl(new O8()));
    }

    public static GenderAttribute gender() {
        return new GenderAttribute();
    }

    public static NameAttribute name() {
        return new NameAttribute();
    }

    public static NotificationsEnabledAttribute notificationsEnabled() {
        return new NotificationsEnabledAttribute();
    }

    public static FirstPartyDataPhoneSha256Attribute phoneHash() {
        return new FirstPartyDataPhoneSha256Attribute(new C0601sl(new We()));
    }

    public static FirstPartyDataTelegramLoginSha256Attribute telegramLoginHash() {
        return new FirstPartyDataTelegramLoginSha256Attribute(new C0601sl(new Dn()));
    }
}
