package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class N8 extends MessageNano {
    public static final int g = 0;
    public static final int h = 1;
    public static final int i = 2;
    public static final int j = 3;
    public static final int k = 4;
    public static final int l = 5;
    public static final int m = 6;
    public static final int n = 7;
    public static volatile N8[] o;
    public int a;
    public M8 b;
    public K8 c;
    public L8 d;
    public C0692w8 e;
    public C8 f;

    public N8() {
        a();
    }

    public static N8[] b() {
        if (o == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (o == null) {
                        o = new N8[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return o;
    }

    public final N8 a() {
        this.a = 0;
        this.b = null;
        this.c = null;
        this.d = null;
        this.e = null;
        this.f = null;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        int i2 = this.a;
        if (i2 != 0) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeInt32Size(1, i2);
        }
        M8 m8 = this.b;
        if (m8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(2, m8);
        }
        K8 k8 = this.c;
        if (k8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(3, k8);
        }
        L8 l8 = this.d;
        if (l8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(4, l8);
        }
        C0692w8 c0692w8 = this.e;
        if (c0692w8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(5, c0692w8);
        }
        C8 c8 = this.f;
        return c8 != null ? CodedOutputByteBufferNano.computeMessageSize(6, c8) + iComputeSerializedSize : iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        int i2 = this.a;
        if (i2 != 0) {
            codedOutputByteBufferNano.writeInt32(1, i2);
        }
        M8 m8 = this.b;
        if (m8 != null) {
            codedOutputByteBufferNano.writeMessage(2, m8);
        }
        K8 k8 = this.c;
        if (k8 != null) {
            codedOutputByteBufferNano.writeMessage(3, k8);
        }
        L8 l8 = this.d;
        if (l8 != null) {
            codedOutputByteBufferNano.writeMessage(4, l8);
        }
        C0692w8 c0692w8 = this.e;
        if (c0692w8 != null) {
            codedOutputByteBufferNano.writeMessage(5, c0692w8);
        }
        C8 c8 = this.f;
        if (c8 != null) {
            codedOutputByteBufferNano.writeMessage(6, c8);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final N8 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag != 0) {
                if (tag == 8) {
                    int int32 = codedInputByteBufferNano.readInt32();
                    switch (int32) {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            this.a = int32;
                            break;
                    }
                } else if (tag == 18) {
                    if (this.b == null) {
                        this.b = new M8();
                    }
                    codedInputByteBufferNano.readMessage(this.b);
                } else if (tag == 26) {
                    if (this.c == null) {
                        this.c = new K8();
                    }
                    codedInputByteBufferNano.readMessage(this.c);
                } else if (tag == 34) {
                    if (this.d == null) {
                        this.d = new L8();
                    }
                    codedInputByteBufferNano.readMessage(this.d);
                } else if (tag == 42) {
                    if (this.e == null) {
                        this.e = new C0692w8();
                    }
                    codedInputByteBufferNano.readMessage(this.e);
                } else if (tag != 50) {
                    if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    }
                } else {
                    if (this.f == null) {
                        this.f = new C8();
                    }
                    codedInputByteBufferNano.readMessage(this.f);
                }
            }
        }
        return this;
    }

    public static N8 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new N8().mergeFrom(codedInputByteBufferNano);
    }

    public static N8 a(byte[] bArr) {
        return (N8) MessageNano.mergeFrom(new N8(), bArr);
    }
}
