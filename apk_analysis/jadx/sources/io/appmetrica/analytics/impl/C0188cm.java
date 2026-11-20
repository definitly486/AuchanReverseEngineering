package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.StartupParamsCallback;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0188cm extends HashMap {
    public C0188cm() {
        put(EnumC0136am.UNKNOWN, StartupParamsCallback.Reason.UNKNOWN);
        put(EnumC0136am.NETWORK, StartupParamsCallback.Reason.NETWORK);
        put(EnumC0136am.PARSE, StartupParamsCallback.Reason.INVALID_RESPONSE);
    }
}
