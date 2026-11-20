package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class H7 implements Converter {
    public final G7 a;

    /* JADX WARN: Multi-variable type inference failed */
    public H7() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    public final byte[] a(I7 i7) {
        return MessageNano.toByteArray(this.a.fromModel(i7));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object fromModel(Object obj) {
        return MessageNano.toByteArray(this.a.fromModel((I7) obj));
    }

    public H7(G7 g7) {
        this.a = g7;
    }

    /* JADX WARN: Code duplicated, block: B:5:0x000f A[Catch: InvalidProtocolBufferNanoException -> 0x0015, TRY_LEAVE, TryCatch #0 {InvalidProtocolBufferNanoException -> 0x0015, blocks: (B:3:0x0002, B:5:0x000f), top: B:10:0x0002 }] */
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final I7 toModel(byte[] bArr) {
        F7 f7;
        if (bArr != null) {
            try {
                f7 = (F7) MessageNano.mergeFrom(new F7(), bArr);
                if (f7 == null) {
                    f7 = new F7();
                }
            } catch (InvalidProtocolBufferNanoException unused) {
                f7 = new F7();
            }
        } else {
            f7 = new F7();
        }
        return this.a.toModel(f7);
    }

    public /* synthetic */ H7(G7 g7, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new G7(null, 1, null) : g7);
    }
}
