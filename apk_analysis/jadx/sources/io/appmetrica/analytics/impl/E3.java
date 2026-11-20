package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class E3 implements InterfaceC0604so {
    @Override // kotlin.jvm.functions.Function2
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<I3> invoke(List<I3> list, I3 i3) {
        if (!(list instanceof Collection) || !list.isEmpty()) {
            Iterator<T> it = list.iterator();
            while (it.hasNext()) {
                EnumC0406l8 enumC0406l8 = ((I3) it.next()).b;
                EnumC0406l8 enumC0406l9 = i3.b;
                if (enumC0406l8 == enumC0406l9) {
                    if (enumC0406l9 != EnumC0406l8.d) {
                        return null;
                    }
                    ArrayList arrayList = new ArrayList();
                    for (Object obj : list) {
                        if (((I3) obj).b != EnumC0406l8.d) {
                            arrayList.add(obj);
                        }
                    }
                    return CollectionsKt.plus(arrayList, i3);
                }
            }
        }
        return CollectionsKt.plus(list, i3);
    }
}
