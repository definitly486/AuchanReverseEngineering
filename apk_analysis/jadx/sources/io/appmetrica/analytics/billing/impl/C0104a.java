package io.appmetrica.analytics.billing.impl;

import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.billing.impl.a, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0104a {
    public final List a;
    public final boolean b;

    public C0104a(List list, boolean z) {
        this.a = list;
        this.b = z;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof C0104a)) {
            return false;
        }
        C0104a c0104a = (C0104a) obj;
        return Intrinsics.areEqual(this.a, c0104a.a) && this.b == c0104a.b;
    }

    public final int hashCode() {
        return Boolean.hashCode(this.b) + (this.a.hashCode() * 31);
    }

    public final String toString() {
        return "AutoInappCollectingInfo(billingInfos=" + this.a + ", firstInappCheckOccurred=" + this.b + ')';
    }
}
