package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.comparisons.ComparisonsKt;
import java.util.Comparator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0723xd implements Comparator {
    @Override // java.util.Comparator
    public final int compare(Object obj, Object obj2) {
        return ComparisonsKt.compareValues(((C0671vd) obj).a, ((C0671vd) obj2).a);
    }
}
