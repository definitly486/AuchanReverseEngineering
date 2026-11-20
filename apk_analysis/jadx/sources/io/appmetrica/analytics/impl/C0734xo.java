package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0734xo extends MessageNano {
    public static final int e = 0;
    public static final int f = 1;
    public static final int g = 2;
    public static final int h = 3;
    public static volatile C0734xo[] i;
    public byte[] a;
    public int b;
    public C0760yo c;
    public C0786zo d;

    public C0734xo() {
        a();
    }

    public static C0734xo[] b() {
        if (i == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (i == null) {
                        i = new C0734xo[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return i;
    }

    public final C0734xo a() {
        this.a = WireFormatNano.EMPTY_BYTES;
        this.b = 0;
        this.c = null;
        this.d = null;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeInt32Size = CodedOutputByteBufferNano.computeInt32Size(2, this.b) + CodedOutputByteBufferNano.computeBytesSize(1, this.a) + super.computeSerializedSize();
        C0760yo c0760yo = this.c;
        if (c0760yo != null) {
            iComputeInt32Size += CodedOutputByteBufferNano.computeMessageSize(3, c0760yo);
        }
        C0786zo c0786zo = this.d;
        return c0786zo != null ? CodedOutputByteBufferNano.computeMessageSize(4, c0786zo) + iComputeInt32Size : iComputeInt32Size;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        codedOutputByteBufferNano.writeBytes(1, this.a);
        codedOutputByteBufferNano.writeInt32(2, this.b);
        C0760yo c0760yo = this.c;
        if (c0760yo != null) {
            codedOutputByteBufferNano.writeMessage(3, c0760yo);
        }
        C0786zo c0786zo = this.d;
        if (c0786zo != null) {
            codedOutputByteBufferNano.writeMessage(4, c0786zo);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0734xo mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                this.a = codedInputByteBufferNano.readBytes();
            } else if (tag == 16) {
                int int32 = codedInputByteBufferNano.readInt32();
                if (int32 == 0 || int32 == 1 || int32 == 2 || int32 == 3) {
                    this.b = int32;
                }
            } else if (tag == 26) {
                if (this.c == null) {
                    this.c = new C0760yo();
                }
                codedInputByteBufferNano.readMessage(this.c);
            } else if (tag != 34) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                if (this.d == null) {
                    this.d = new C0786zo();
                }
                codedInputByteBufferNano.readMessage(this.d);
            }
        }
        return this;
    }

    public static C0734xo b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0734xo().mergeFrom(codedInputByteBufferNano);
    }

    public static C0734xo a(byte[] bArr) {
        return (C0734xo) MessageNano.mergeFrom(new C0734xo(), bArr);
    }
}
