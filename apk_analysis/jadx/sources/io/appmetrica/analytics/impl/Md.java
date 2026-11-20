package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreutils.internal.reflection.ReflectionUtils;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Md {
    public static ArrayList a() {
        C0671vd c0671vd;
        List<String> listA = C0584s4.l().m.a();
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(listA, 10));
        for (String str : listA) {
            Object objLoadAndInstantiateClassWithDefaultConstructor = ReflectionUtils.loadAndInstantiateClassWithDefaultConstructor(str, ModuleClientEntryPoint.class);
            if (objLoadAndInstantiateClassWithDefaultConstructor == null) {
                c0671vd = new C0671vd(str, false);
            } else {
                C0584s4.l().m().b.add((ModuleClientEntryPoint) objLoadAndInstantiateClassWithDefaultConstructor);
                c0671vd = new C0671vd(str, true);
            }
            arrayList.add(c0671vd);
        }
        return arrayList;
    }
}
