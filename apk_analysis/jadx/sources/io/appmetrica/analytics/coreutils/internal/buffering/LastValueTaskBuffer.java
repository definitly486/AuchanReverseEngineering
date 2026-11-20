package io.appmetrica.analytics.coreutils.internal.buffering;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class LastValueTaskBuffer<T> implements TaskBuffer<T> {
    private Object a;

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public void add(T t) {
        this.a = t;
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public List<T> getAndClear() {
        Object obj = this.a;
        this.a = null;
        return obj != null ? CollectionsKt.listOf(obj) : CollectionsKt.emptyList();
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public boolean isEmpty() {
        return this.a == null;
    }
}
