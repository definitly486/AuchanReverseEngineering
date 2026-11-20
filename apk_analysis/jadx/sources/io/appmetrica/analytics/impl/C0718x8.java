package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.x8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0718x8 extends MessageNano {
    public static volatile C0718x8[] e;
    public G8 a;
    public I8 b;
    public C0770z8 c;
    public F8 d;

    public C0718x8() {
        a();
    }

    public static C0718x8[] b() {
        if (e == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (e == null) {
                        e = new C0718x8[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return e;
    }

    public final C0718x8 a() {
        this.a = null;
        this.b = null;
        this.c = null;
        this.d = null;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        G8 g8 = this.a;
        if (g8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(1, g8);
        }
        I8 i8 = this.b;
        if (i8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(2, i8);
        }
        C0770z8 c0770z8 = this.c;
        if (c0770z8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(3, c0770z8);
        }
        F8 f8 = this.d;
        return f8 != null ? CodedOutputByteBufferNano.computeMessageSize(4, f8) + iComputeSerializedSize : iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        G8 g8 = this.a;
        if (g8 != null) {
            codedOutputByteBufferNano.writeMessage(1, g8);
        }
        I8 i8 = this.b;
        if (i8 != null) {
            codedOutputByteBufferNano.writeMessage(2, i8);
        }
        C0770z8 c0770z8 = this.c;
        if (c0770z8 != null) {
            codedOutputByteBufferNano.writeMessage(3, c0770z8);
        }
        F8 f8 = this.d;
        if (f8 != null) {
            codedOutputByteBufferNano.writeMessage(4, f8);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0718x8 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                if (this.a == null) {
                    this.a = new G8();
                }
                codedInputByteBufferNano.readMessage(this.a);
            } else if (tag == 18) {
                if (this.b == null) {
                    this.b = new I8();
                }
                codedInputByteBufferNano.readMessage(this.b);
            } else if (tag == 26) {
                if (this.c == null) {
                    this.c = new C0770z8();
                }
                codedInputByteBufferNano.readMessage(this.c);
            } else if (tag != 34) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                if (this.d == null) {
                    this.d = new F8();
                }
                codedInputByteBufferNano.readMessage(this.d);
            }
        }
        return this;
    }

    public static C0718x8 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0718x8().mergeFrom(codedInputByteBufferNano);
    }

    public static C0718x8 a(byte[] bArr) {
        return (C0718x8) MessageNano.mergeFrom(new C0718x8(), bArr);
    }
}
