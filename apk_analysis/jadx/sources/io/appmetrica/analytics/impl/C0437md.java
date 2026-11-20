package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.md, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0437md {
    public final ArrayList a = new ArrayList();

    public final synchronized List a() {
        ArrayList arrayList;
        try {
            ArrayList arrayList2 = this.a;
            ArrayList arrayList3 = new ArrayList(CollectionsKt.collectionSizeOrDefault(arrayList2, 10));
            int size = arrayList2.size();
            int i = 0;
            int i2 = 0;
            while (i2 < size) {
                Object obj = arrayList2.get(i2);
                i2++;
                arrayList3.add(((G5) obj).a);
            }
            arrayList = new ArrayList();
            int size2 = arrayList3.size();
            while (i < size2) {
                Object obj2 = arrayList3.get(i);
                i++;
                if (((String) obj2).length() > 0) {
                    arrayList.add(obj2);
                }
            }
        } catch (Throwable th) {
            throw th;
        }
        return CollectionsKt.distinct(arrayList);
    }
}
