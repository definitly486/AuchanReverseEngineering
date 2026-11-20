package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class cp implements InterfaceC0631u {
    @Override // io.appmetrica.analytics.impl.InterfaceC0631u
    public final Map<String, String> a(Map<String, String> map) {
        map.put(AdRevenueConstants.SOURCE_KEY, "yandex");
        return map;
    }
}
