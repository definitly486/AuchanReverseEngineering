package io.appmetrica.analytics.remotepermissions.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import io.appmetrica.analytics.coreapi.internal.permission.PermissionStrategy;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class d implements PermissionStrategy {
    public Set a = SetsKt.emptySet();

    public final synchronized void a(Set<String> set) {
        this.a = set;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.permission.PermissionStrategy
    public final synchronized boolean forbidUsePermission(String str) {
        return !this.a.contains(str);
    }
}
