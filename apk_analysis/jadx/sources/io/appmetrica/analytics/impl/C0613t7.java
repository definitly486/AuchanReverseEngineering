package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.t7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0613t7 implements Converter {
    public final C0587s7 a;

    /* JADX WARN: Multi-variable type inference failed */
    public C0613t7() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    public final byte[] a(C0639u7 c0639u7) {
        return MessageNano.toByteArray(this.a.fromModel(c0639u7));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object fromModel(Object obj) {
        return MessageNano.toByteArray(this.a.fromModel((C0639u7) obj));
    }

    public C0613t7(C0587s7 c0587s7) {
        this.a = c0587s7;
    }

    /* JADX WARN: Code duplicated, block: B:5:0x000f A[Catch: InvalidProtocolBufferNanoException -> 0x0015, TRY_LEAVE, TryCatch #0 {InvalidProtocolBufferNanoException -> 0x0015, blocks: (B:3:0x0002, B:5:0x000f), top: B:10:0x0002 }] */
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0639u7 toModel(byte[] bArr) {
        D7 d7;
        if (bArr != null) {
            try {
                d7 = (D7) MessageNano.mergeFrom(new D7(), bArr);
                if (d7 == null) {
                    d7 = new D7();
                }
            } catch (InvalidProtocolBufferNanoException unused) {
                d7 = new D7();
            }
        } else {
            d7 = new D7();
        }
        return this.a.toModel(d7);
    }

    /* JADX WARN: Multi-variable type inference failed */
    public /* synthetic */ C0613t7(C0587s7 c0587s7, int i, DefaultConstructorMarker defaultConstructorMarker) {
        if ((i & 1) != 0) {
            c0587s7 = new C0587s7(null, 0 == true ? 1 : 0, 3, 0 == true ? 1 : 0);
        }
        this(c0587s7);
    }
}
