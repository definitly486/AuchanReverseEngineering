package io.appmetrica.analytics.coreutils.internal;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.LinkedHashSet;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class ReferenceHolder {
    private final LinkedHashSet a = new LinkedHashSet();

    public final Set<Object> peekReferences() {
        return CollectionsKt.toSet(this.a);
    }

    public final void removeReference(Object obj) {
        this.a.remove(obj);
    }

    public final void storeReference(Object obj) {
        this.a.add(obj);
    }
}
