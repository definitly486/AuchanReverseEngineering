package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.LinkedList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Jo implements Ko {
    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(List<Io> list) {
        LinkedList linkedList = new LinkedList();
        boolean z = true;
        for (Io io2 : list) {
            if (!io2.a) {
                linkedList.add(io2.b);
                z = false;
            }
        }
        return z ? new Io(this, true, "") : new Io(this, false, CollectionsKt.joinToString(linkedList, ", ", "", "", -1, "", null));
    }
}
