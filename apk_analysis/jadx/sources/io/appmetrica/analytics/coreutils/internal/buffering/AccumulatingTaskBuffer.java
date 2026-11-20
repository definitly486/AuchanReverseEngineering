package io.appmetrica.analytics.coreutils.internal.buffering;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class AccumulatingTaskBuffer<T> implements TaskBuffer<T> {
    private final ArrayList a = new ArrayList();

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public void add(T t) {
        this.a.add(t);
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public List<T> getAndClear() {
        if (this.a.isEmpty()) {
            return CollectionsKt.emptyList();
        }
        List<T> list = CollectionsKt.toList(this.a);
        this.a.clear();
        return list;
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public boolean isEmpty() {
        return this.a.isEmpty();
    }
}
