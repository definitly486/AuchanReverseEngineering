package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import java.util.HashMap;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.un, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0655un extends Lambda implements Function0 {
    public final /* synthetic */ C0681vn a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0655un(C0681vn c0681vn) {
        super(0);
        this.a = c0681vn;
    }

    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        HashMap map = new HashMap();
        C0681vn c0681vn = this.a;
        String strA = c0681vn.a.a();
        if (strA != null) {
        }
        String strA2 = c0681vn.b.a();
        if (strA2 != null) {
            map.put(AdRevenueConstants.PLUGIN_SUPPORTED_SOURCES_KEY, strA2);
        }
        return map;
    }
}
