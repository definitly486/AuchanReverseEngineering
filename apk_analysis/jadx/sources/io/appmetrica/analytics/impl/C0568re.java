package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.permission.PermissionStrategy;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.re, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0568re implements PermissionStrategy {
    @Override // io.appmetrica.analytics.coreapi.internal.permission.PermissionStrategy
    public final boolean forbidUsePermission(String str) {
        return false;
    }

    public final String toString() {
        return "AlwaysAskForPermissionStrategy{always allow permission}";
    }
}
