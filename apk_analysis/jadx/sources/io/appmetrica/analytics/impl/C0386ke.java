package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ke, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0386ke implements InterfaceC0631u {
    @Override // io.appmetrica.analytics.impl.InterfaceC0631u
    public final Map<String, String> a(Map<String, String> map) {
        map.put(AdRevenueConstants.LAYER_KEY, "native");
        return map;
    }
}
