package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0692w8 extends MessageNano {
    public static volatile C0692w8[] b;
    public C0718x8 a;

    public C0692w8() {
        a();
    }

    public static C0692w8[] b() {
        if (b == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (b == null) {
                        b = new C0692w8[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return b;
    }

    public final C0692w8 a() {
        this.a = null;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0718x8 c0718x8 = this.a;
        return c0718x8 != null ? CodedOutputByteBufferNano.computeMessageSize(1, c0718x8) + iComputeSerializedSize : iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0718x8 c0718x8 = this.a;
        if (c0718x8 != null) {
            codedOutputByteBufferNano.writeMessage(1, c0718x8);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0692w8 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag != 10) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                if (this.a == null) {
                    this.a = new C0718x8();
                }
                codedInputByteBufferNano.readMessage(this.a);
            }
        }
        return this;
    }

    public static C0692w8 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0692w8().mergeFrom(codedInputByteBufferNano);
    }

    public static C0692w8 a(byte[] bArr) {
        return (C0692w8) MessageNano.mergeFrom(new C0692w8(), bArr);
    }
}
