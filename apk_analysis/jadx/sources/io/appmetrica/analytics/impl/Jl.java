package io.appmetrica.analytics.impl;

import android.annotation.TargetApi;
import android.telephony.SubscriptionInfo;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;
import io.appmetrica.analytics.coreutils.internal.parsing.ParseUtils;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(29)
public final class Jl {
    public static final Jl a = new Jl();

    private Jl() {
    }

    public static final Integer a(SubscriptionInfo subscriptionInfo) {
        return ParseUtils.intValueOf(subscriptionInfo.getMccString());
    }

    public static final Integer b(SubscriptionInfo subscriptionInfo) {
        return ParseUtils.intValueOf(subscriptionInfo.getMncString());
    }
}
