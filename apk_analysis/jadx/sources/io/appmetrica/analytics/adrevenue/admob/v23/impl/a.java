package io.appmetrica.analytics.adrevenue.admob.v23.impl;

import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessor;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class a implements ModuleAdRevenueProcessor {
    public final ArrayList a;

    public a(b bVar, ClientContext clientContext) {
        ArrayList arrayList = new ArrayList();
        this.a = arrayList;
        arrayList.add(new d(bVar, clientContext));
        arrayList.add(new f(bVar, clientContext));
        arrayList.add(new g(bVar, clientContext));
        arrayList.add(new h(bVar, clientContext));
        arrayList.add(new i(bVar, clientContext));
        arrayList.add(new c(bVar, clientContext));
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessor
    public final String getDescription() {
        return "AdMob";
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessor
    public final boolean process(Object... objArr) {
        ArrayList arrayList = this.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            if (((ModuleAdRevenueProcessor) obj).process(objArr)) {
                return true;
            }
        }
        return false;
    }
}
