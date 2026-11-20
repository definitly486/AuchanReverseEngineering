package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;
import java.util.Arrays;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0404l6 extends MessageNano {
    public static final int k = 0;
    public static final int l = 1;
    public static volatile C0404l6[] m;
    public static byte[] n;
    public static volatile boolean o;
    public C0560r6 a;
    public C0301h6 b;
    public String c;
    public int d;
    public C0508p6[] e;
    public int f;
    public C0378k6 g;
    public byte[] h;
    public byte[] i;
    public C0352j6[] j;

    public C0404l6() {
        if (!o) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (!o) {
                        n = InternalNano.bytesDefaultValue("JVM");
                        o = true;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        a();
    }

    public static C0404l6[] b() {
        if (m == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (m == null) {
                        m = new C0404l6[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return m;
    }

    public final C0404l6 a() {
        this.a = null;
        this.b = null;
        this.c = "";
        this.d = -1;
        this.e = C0508p6.b();
        this.f = 0;
        this.g = null;
        this.h = (byte[]) n.clone();
        this.i = WireFormatNano.EMPTY_BYTES;
        this.j = C0352j6.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0560r6 c0560r6 = this.a;
        if (c0560r6 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(1, c0560r6);
        }
        C0301h6 c0301h6 = this.b;
        if (c0301h6 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(2, c0301h6);
        }
        if (!this.c.equals("")) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeStringSize(3, this.c);
        }
        int i = this.d;
        if (i != -1) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeInt32Size(4, i);
        }
        C0508p6[] c0508p6Arr = this.e;
        int i2 = 0;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i3 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.e;
                if (i3 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i3];
                if (c0508p6 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(5, c0508p6) + iComputeSerializedSize;
                }
                i3++;
            }
        }
        int i4 = this.f;
        if (i4 != 0) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeInt32Size(6, i4);
        }
        C0378k6 c0378k6 = this.g;
        if (c0378k6 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(7, c0378k6);
        }
        if (!Arrays.equals(this.h, n)) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeBytesSize(8, this.h);
        }
        if (!Arrays.equals(this.i, WireFormatNano.EMPTY_BYTES)) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeBytesSize(9, this.i);
        }
        C0352j6[] c0352j6Arr = this.j;
        if (c0352j6Arr != null && c0352j6Arr.length > 0) {
            while (true) {
                C0352j6[] c0352j6Arr2 = this.j;
                if (i2 >= c0352j6Arr2.length) {
                    break;
                }
                C0352j6 c0352j6 = c0352j6Arr2[i2];
                if (c0352j6 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(10, c0352j6) + iComputeSerializedSize;
                }
                i2++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0560r6 c0560r6 = this.a;
        if (c0560r6 != null) {
            codedOutputByteBufferNano.writeMessage(1, c0560r6);
        }
        C0301h6 c0301h6 = this.b;
        if (c0301h6 != null) {
            codedOutputByteBufferNano.writeMessage(2, c0301h6);
        }
        if (!this.c.equals("")) {
            codedOutputByteBufferNano.writeString(3, this.c);
        }
        int i = this.d;
        if (i != -1) {
            codedOutputByteBufferNano.writeInt32(4, i);
        }
        C0508p6[] c0508p6Arr = this.e;
        int i2 = 0;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i3 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.e;
                if (i3 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i3];
                if (c0508p6 != null) {
                    codedOutputByteBufferNano.writeMessage(5, c0508p6);
                }
                i3++;
            }
        }
        int i4 = this.f;
        if (i4 != 0) {
            codedOutputByteBufferNano.writeInt32(6, i4);
        }
        C0378k6 c0378k6 = this.g;
        if (c0378k6 != null) {
            codedOutputByteBufferNano.writeMessage(7, c0378k6);
        }
        if (!Arrays.equals(this.h, n)) {
            codedOutputByteBufferNano.writeBytes(8, this.h);
        }
        if (!Arrays.equals(this.i, WireFormatNano.EMPTY_BYTES)) {
            codedOutputByteBufferNano.writeBytes(9, this.i);
        }
        C0352j6[] c0352j6Arr = this.j;
        if (c0352j6Arr != null && c0352j6Arr.length > 0) {
            while (true) {
                C0352j6[] c0352j6Arr2 = this.j;
                if (i2 >= c0352j6Arr2.length) {
                    break;
                }
                C0352j6 c0352j6 = c0352j6Arr2[i2];
                if (c0352j6 != null) {
                    codedOutputByteBufferNano.writeMessage(10, c0352j6);
                }
                i2++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    public static C0404l6 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0404l6().mergeFrom(codedInputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0404l6 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            switch (tag) {
                case 0:
                    break;
                case 10:
                    if (this.a == null) {
                        this.a = new C0560r6();
                    }
                    codedInputByteBufferNano.readMessage(this.a);
                    break;
                case 18:
                    if (this.b == null) {
                        this.b = new C0301h6();
                    }
                    codedInputByteBufferNano.readMessage(this.b);
                    break;
                case 26:
                    this.c = codedInputByteBufferNano.readString();
                    break;
                case 32:
                    int int32 = codedInputByteBufferNano.readInt32();
                    if (int32 == -1 || int32 == 0 || int32 == 1) {
                        this.d = int32;
                    }
                    break;
                case 42:
                    int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 42);
                    C0508p6[] c0508p6Arr = this.e;
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
                    this.e = c0508p6Arr2;
                    break;
                case 48:
                    int int33 = codedInputByteBufferNano.readInt32();
                    if (int33 == 0 || int33 == 1) {
                        this.f = int33;
                    }
                    break;
                case 58:
                    if (this.g == null) {
                        this.g = new C0378k6();
                    }
                    codedInputByteBufferNano.readMessage(this.g);
                    break;
                case 66:
                    this.h = codedInputByteBufferNano.readBytes();
                    break;
                case 74:
                    this.i = codedInputByteBufferNano.readBytes();
                    break;
                case 82:
                    int repeatedFieldArrayLength2 = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 82);
                    C0352j6[] c0352j6Arr = this.j;
                    int length2 = c0352j6Arr == null ? 0 : c0352j6Arr.length;
                    int i2 = repeatedFieldArrayLength2 + length2;
                    C0352j6[] c0352j6Arr2 = new C0352j6[i2];
                    if (length2 != 0) {
                        System.arraycopy(c0352j6Arr, 0, c0352j6Arr2, 0, length2);
                    }
                    while (length2 < i2 - 1) {
                        C0352j6 c0352j6 = new C0352j6();
                        c0352j6Arr2[length2] = c0352j6;
                        codedInputByteBufferNano.readMessage(c0352j6);
                        codedInputByteBufferNano.readTag();
                        length2++;
                    }
                    C0352j6 c0352j7 = new C0352j6();
                    c0352j6Arr2[length2] = c0352j7;
                    codedInputByteBufferNano.readMessage(c0352j7);
                    this.j = c0352j6Arr2;
                    break;
                default:
                    if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    }
                    break;
            }
        }
        return this;
    }

    public static C0404l6 a(byte[] bArr) {
        return (C0404l6) MessageNano.mergeFrom(new C0404l6(), bArr);
    }
}
