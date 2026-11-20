package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.nn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0473nn implements InterfaceC0708wo {
    public final ArrayList a;

    public C0473nn(String str, List<String> list, int i, Cdo cdo, Ko ko, W2 w2) {
        List listTake = CollectionsKt.take(CollectionsKt.toList(CollectionsKt.toSet(list)), i);
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(listTake, 10));
        int i2 = 0;
        for (Object obj : listTake) {
            int i3 = i2 + 1;
            if (i2 < 0) {
                CollectionsKt.throwIndexOverflow();
            }
            arrayList.add(new C0525pn(str + '_' + i2, (String) obj, cdo, ko, w2));
            i2 = i3;
        }
        this.a = arrayList;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0708wo
    public final void a(C0682vo c0682vo) {
        ArrayList arrayList = this.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((C0525pn) obj).a(c0682vo);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0708wo
    public final void a(PublicLogger publicLogger) {
        ArrayList arrayList = this.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((C0525pn) obj).e = publicLogger;
        }
    }
}
