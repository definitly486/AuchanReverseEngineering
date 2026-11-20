package io.appmetrica.analytics.billing.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.billinginterface.internal.BillingInfo;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: renamed from: io.appmetrica.analytics.billing.impl.b, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0105b implements ProtobufConverter {
    public final i a;

    /* JADX WARN: Multi-variable type inference failed */
    public C0105b() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final d fromModel(C0104a c0104a) {
        d dVar = new d();
        List list = c0104a.a;
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
        Iterator it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(this.a.fromModel((BillingInfo) it.next()));
        }
        dVar.a = (c[]) arrayList.toArray(new c[0]);
        dVar.b = c0104a.b;
        return dVar;
    }

    public C0105b(i iVar) {
        this.a = iVar;
    }

    public /* synthetic */ C0105b(i iVar, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new i() : iVar);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0104a toModel(d dVar) {
        c[] cVarArr = dVar.a;
        ArrayList arrayList = new ArrayList(cVarArr.length);
        for (c cVar : cVarArr) {
            arrayList.add(this.a.toModel(cVar));
        }
        return new C0104a(arrayList, dVar.b);
    }
}
