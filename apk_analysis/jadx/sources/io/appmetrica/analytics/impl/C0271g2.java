package io.appmetrica.analytics.impl;

import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0271g2 {
    public final List a;
    public final K2 b;
    public final List c;

    public C0271g2(List list, K2 k2, List list2) {
        this.a = list;
        this.b = k2;
        this.c = list2;
    }

    public final String toString() {
        return "AppPermissionsState{mPermissionStateList=" + this.a + ", mBackgroundRestrictionsState=" + this.b + ", mAvailableProviders=" + this.c + '}';
    }
}
