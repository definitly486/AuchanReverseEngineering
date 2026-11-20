package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class A9 extends MessageNano {
    public static final int d = 0;
    public static final int e = 1;
    public static final int f = 2;
    public static final int g = 3;
    public static final int h = 4;
    public static final int i = 5;
    public static final int j = 6;
    public static final int k = 7;
    public static final int l = 8;
    public static final int m = 9;
    public static final int n = 10;
    public static final int o = 11;
    public static final int p = 12;
    public static volatile A9[] q;
    public long a;
    public C0771z9 b;
    public C0745y9[] c;

    public A9() {
        a();
    }

    public static A9[] b() {
        if (q == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (q == null) {
                        q = new A9[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return q;
    }

    public final A9 a() {
        this.a = 0L;
        this.b = null;
        this.c = C0745y9.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeUInt64Size = CodedOutputByteBufferNano.computeUInt64Size(1, this.a) + super.computeSerializedSize();
        C0771z9 c0771z9 = this.b;
        if (c0771z9 != null) {
            iComputeUInt64Size += CodedOutputByteBufferNano.computeMessageSize(2, c0771z9);
        }
        C0745y9[] c0745y9Arr = this.c;
        if (c0745y9Arr != null && c0745y9Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0745y9[] c0745y9Arr2 = this.c;
                if (i2 >= c0745y9Arr2.length) {
                    break;
                }
                C0745y9 c0745y9 = c0745y9Arr2[i2];
                if (c0745y9 != null) {
                    iComputeUInt64Size = CodedOutputByteBufferNano.computeMessageSize(3, c0745y9) + iComputeUInt64Size;
                }
                i2++;
            }
        }
        return iComputeUInt64Size;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        codedOutputByteBufferNano.writeUInt64(1, this.a);
        C0771z9 c0771z9 = this.b;
        if (c0771z9 != null) {
            codedOutputByteBufferNano.writeMessage(2, c0771z9);
        }
        C0745y9[] c0745y9Arr = this.c;
        if (c0745y9Arr != null && c0745y9Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0745y9[] c0745y9Arr2 = this.c;
                if (i2 >= c0745y9Arr2.length) {
                    break;
                }
                C0745y9 c0745y9 = c0745y9Arr2[i2];
                if (c0745y9 != null) {
                    codedOutputByteBufferNano.writeMessage(3, c0745y9);
                }
                i2++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final A9 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 8) {
                this.a = codedInputByteBufferNano.readUInt64();
            } else if (tag == 18) {
                if (this.b == null) {
                    this.b = new C0771z9();
                }
                codedInputByteBufferNano.readMessage(this.b);
            } else if (tag != 26) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 26);
                C0745y9[] c0745y9Arr = this.c;
                int length = c0745y9Arr == null ? 0 : c0745y9Arr.length;
                int i2 = repeatedFieldArrayLength + length;
                C0745y9[] c0745y9Arr2 = new C0745y9[i2];
                if (length != 0) {
                    System.arraycopy(c0745y9Arr, 0, c0745y9Arr2, 0, length);
                }
                while (length < i2 - 1) {
                    C0745y9 c0745y9 = new C0745y9();
                    c0745y9Arr2[length] = c0745y9;
                    codedInputByteBufferNano.readMessage(c0745y9);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0745y9 c0745y10 = new C0745y9();
                c0745y9Arr2[length] = c0745y10;
                codedInputByteBufferNano.readMessage(c0745y10);
                this.c = c0745y9Arr2;
            }
        }
        return this;
    }

    public static A9 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new A9().mergeFrom(codedInputByteBufferNano);
    }

    public static A9 a(byte[] bArr) {
        return (A9) MessageNano.mergeFrom(new A9(), bArr);
    }
}
