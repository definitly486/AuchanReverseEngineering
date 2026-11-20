package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0680vm {
    public final ProtobufStateStorage a;
    public final Oo b;

    public C0680vm(ProtobufStateStorage protobufStateStorage, Oo oo) {
        this.a = protobufStateStorage;
        this.b = oo;
    }

    public C0680vm(Context context) {
        this(((AbstractC0343in) C0292gn.a(Am.class)).create(context), Ka.k().D().a());
    }
}
