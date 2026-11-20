package io.appmetrica.analytics.remotepermissions.internal.config;

import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class FeatureConfig {
    private final Set a;

    public FeatureConfig(Set<String> set) {
        this.a = set;
    }

    public final Set<String> getPermittedPermissions() {
        return this.a;
    }

    public String toString() {
        return "FeatureConfig(permittedPermissions=" + this.a + ')';
    }
}
