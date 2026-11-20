package io.appmetrica.analytics.coreapi.internal.data;

/* JADX INFO: loaded from: classes3.dex */
public interface Converter<S, P> {
    P fromModel(S s);

    S toModel(P p);
}
