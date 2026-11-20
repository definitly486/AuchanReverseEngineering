package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.lo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0422lo {
    public static final C0344io a(Throwable th, X x, List list, String str, Boolean bool) {
        ArrayList arrayList = null;
        Yn ynA = th != null ? Zn.a(th, 1, 0) : null;
        if (list != null) {
            arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
            Iterator it = list.iterator();
            while (it.hasNext()) {
                arrayList.add(new Ul((StackTraceElement) it.next()));
            }
        }
        return new C0344io(ynA, x, arrayList, null, null, null, str, bool);
    }
}
