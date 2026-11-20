package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0535q6 extends MessageNano {
    public static volatile C0535q6[] g;
    public String a;
    public int b;
    public long c;
    public String d;
    public int e;
    public C0508p6[] f;

    public C0535q6() {
        a();
    }

    public static C0535q6[] b() {
        if (g == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (g == null) {
                        g = new C0535q6[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return g;
    }

    public final C0535q6 a() {
        this.a = "";
        this.b = 0;
        this.c = 0L;
        this.d = "";
        this.e = 0;
        this.f = C0508p6.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSInt64Size = CodedOutputByteBufferNano.computeSInt64Size(3, this.c) + CodedOutputByteBufferNano.computeSInt32Size(2, this.b) + CodedOutputByteBufferNano.computeStringSize(1, this.a) + super.computeSerializedSize();
        if (!this.d.equals("")) {
            iComputeSInt64Size += CodedOutputByteBufferNano.computeStringSize(4, this.d);
        }
        int i = this.e;
        if (i != 0) {
            iComputeSInt64Size += CodedOutputByteBufferNano.computeUInt32Size(5, i);
        }
        C0508p6[] c0508p6Arr = this.f;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.f;
                if (i2 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i2];
                if (c0508p6 != null) {
                    iComputeSInt64Size = CodedOutputByteBufferNano.computeMessageSize(6, c0508p6) + iComputeSInt64Size;
                }
                i2++;
            }
        }
        return iComputeSInt64Size;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        codedOutputByteBufferNano.writeString(1, this.a);
        codedOutputByteBufferNano.writeSInt32(2, this.b);
        codedOutputByteBufferNano.writeSInt64(3, this.c);
        if (!this.d.equals("")) {
            codedOutputByteBufferNano.writeString(4, this.d);
        }
        int i = this.e;
        if (i != 0) {
            codedOutputByteBufferNano.writeUInt32(5, i);
        }
        C0508p6[] c0508p6Arr = this.f;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.f;
                if (i2 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i2];
                if (c0508p6 != null) {
                    codedOutputByteBufferNano.writeMessage(6, c0508p6);
                }
                i2++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0535q6 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                this.a = codedInputByteBufferNano.readString();
            } else if (tag == 16) {
                this.b = codedInputByteBufferNano.readSInt32();
            } else if (tag == 24) {
                this.c = codedInputByteBufferNano.readSInt64();
            } else if (tag == 34) {
                this.d = codedInputByteBufferNano.readString();
            } else if (tag == 40) {
                this.e = codedInputByteBufferNano.readUInt32();
            } else if (tag != 50) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 50);
                C0508p6[] c0508p6Arr = this.f;
                int length = c0508p6Arr == null ? 0 : c0508p6Arr.length;
                int i = repeatedFieldArrayLength + length;
                C0508p6[] c0508p6Arr2 = new C0508p6[i];
                if (length != 0) {
                    System.arraycopy(c0508p6Arr, 0, c0508p6Arr2, 0, length);
                }
                while (length < i - 1) {
                    C0508p6 c0508p6 = new C0508p6();
                    c0508p6Arr2[length] = c0508p6;
                    codedInputByteBufferNano.readMessage(c0508p6);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0508p6 c0508p7 = new C0508p6();
                c0508p6Arr2[length] = c0508p7;
                codedInputByteBufferNano.readMessage(c0508p7);
                this.f = c0508p6Arr2;
            }
        }
        return this;
    }

    public static C0535q6 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0535q6().mergeFrom(codedInputByteBufferNano);
    }

    public static C0535q6 a(byte[] bArr) {
        return (C0535q6) MessageNano.mergeFrom(new C0535q6(), bArr);
    }
}
