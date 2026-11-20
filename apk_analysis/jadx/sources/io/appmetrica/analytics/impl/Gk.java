package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;

/* JADX INFO: loaded from: classes3.dex */
public final class Gk implements InterfaceC0205dd {
    @Override // io.appmetrica.analytics.impl.InterfaceC0205dd
    public final void a(Context context) {
        AbstractC0343in abstractC0343in = (AbstractC0343in) C0292gn.a(Am.class);
        ProtobufStateStorage<Object> protobufStateStorageA = abstractC0343in.a(context, abstractC0343in.b(context));
        Am am = (Am) protobufStateStorageA.read();
        C0784zm c0784zmA = am.a(am.m);
        c0784zmA.o = 0L;
        protobufStateStorageA.save(new Am(c0784zmA));
    }
}
