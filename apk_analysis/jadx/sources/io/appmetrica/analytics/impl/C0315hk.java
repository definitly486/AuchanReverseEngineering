package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.hk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0315hk {
    public final String a;
    public final String b;

    public C0315hk(String str, String str2) {
        this.a = str;
        this.b = str2;
    }

    public final String toString() {
        return "SelfReportingLazyEvent(eventName='" + this.a + "', eventValue='" + this.b + "')";
    }
}
