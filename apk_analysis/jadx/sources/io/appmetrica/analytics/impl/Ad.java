package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import io.appmetrica.analytics.modulesapi.internal.service.event.ModuleServiceEventHandler;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import kotlin.jvm.internal.StringCompanionObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Ad extends AbstractC0131ah {
    public final ArrayList b;

    public Ad(C0455n5 c0455n5) {
        super(c0455n5);
        String strB = c0455n5.a().b();
        strB = strB == null ? "empty" : strB;
        StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
        String.format("[ModulesEventHandler-%s]", Arrays.copyOf(new Object[]{strB}, 1));
        LinkedHashMap linkedHashMapA = Ka.k().o().a(strB);
        ArrayList arrayList = new ArrayList(linkedHashMapA.size());
        for (Map.Entry entry : linkedHashMapA.entrySet()) {
            arrayList.add(TuplesKt.to(entry.getValue(), new C0463nd(c0455n5, (String) entry.getKey())));
        }
        this.b = arrayList;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        ArrayList arrayList;
        if (this.a.t.c() && ((arrayList = this.b) == null || !arrayList.isEmpty())) {
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                Pair pair = (Pair) obj;
                ModuleServiceEventHandler moduleServiceEventHandler = (ModuleServiceEventHandler) pair.component1();
                C0463nd c0463nd = (C0463nd) pair.component2();
                if (moduleServiceEventHandler.handle(new C0542qd(c0463nd.b, c0463nd.a, new C0515pd(c0463nd.e, c0463nd.d, c0463nd.c, c0249f6)), c0249f6)) {
                    return true;
                }
            }
        }
        return false;
    }
}
