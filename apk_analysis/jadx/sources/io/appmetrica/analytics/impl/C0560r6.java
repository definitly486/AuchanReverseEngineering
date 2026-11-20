package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0560r6 extends MessageNano {
    public static volatile C0560r6[] f;
    public String a;
    public String b;
    public C0508p6[] c;
    public C0560r6 d;
    public C0560r6[] e;

    public C0560r6() {
        a();
    }

    public static C0560r6[] b() {
        if (f == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (f == null) {
                        f = new C0560r6[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return f;
    }

    public final C0560r6 a() {
        this.a = "";
        this.b = "";
        this.c = C0508p6.b();
        this.d = null;
        this.e = b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeStringSize = CodedOutputByteBufferNano.computeStringSize(1, this.a) + super.computeSerializedSize();
        if (!this.b.equals("")) {
            iComputeStringSize += CodedOutputByteBufferNano.computeStringSize(2, this.b);
        }
        C0508p6[] c0508p6Arr = this.c;
        int i = 0;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.c;
                if (i2 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i2];
                if (c0508p6 != null) {
                    iComputeStringSize = CodedOutputByteBufferNano.computeMessageSize(3, c0508p6) + iComputeStringSize;
                }
                i2++;
            }
        }
        C0560r6 c0560r6 = this.d;
        if (c0560r6 != null) {
            iComputeStringSize += CodedOutputByteBufferNano.computeMessageSize(4, c0560r6);
        }
        C0560r6[] c0560r6Arr = this.e;
        if (c0560r6Arr != null && c0560r6Arr.length > 0) {
            while (true) {
                C0560r6[] c0560r6Arr2 = this.e;
                if (i >= c0560r6Arr2.length) {
                    break;
                }
                C0560r6 c0560r7 = c0560r6Arr2[i];
                if (c0560r7 != null) {
                    iComputeStringSize = CodedOutputByteBufferNano.computeMessageSize(5, c0560r7) + iComputeStringSize;
                }
                i++;
            }
        }
        return iComputeStringSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        codedOutputByteBufferNano.writeString(1, this.a);
        if (!this.b.equals("")) {
            codedOutputByteBufferNano.writeString(2, this.b);
        }
        C0508p6[] c0508p6Arr = this.c;
        int i = 0;
        if (c0508p6Arr != null && c0508p6Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0508p6[] c0508p6Arr2 = this.c;
                if (i2 >= c0508p6Arr2.length) {
                    break;
                }
                C0508p6 c0508p6 = c0508p6Arr2[i2];
                if (c0508p6 != null) {
                    codedOutputByteBufferNano.writeMessage(3, c0508p6);
                }
                i2++;
            }
        }
        C0560r6 c0560r6 = this.d;
        if (c0560r6 != null) {
            codedOutputByteBufferNano.writeMessage(4, c0560r6);
        }
        C0560r6[] c0560r6Arr = this.e;
        if (c0560r6Arr != null && c0560r6Arr.length > 0) {
            while (true) {
                C0560r6[] c0560r6Arr2 = this.e;
                if (i >= c0560r6Arr2.length) {
                    break;
                }
                C0560r6 c0560r7 = c0560r6Arr2[i];
                if (c0560r7 != null) {
                    codedOutputByteBufferNano.writeMessage(5, c0560r7);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0560r6 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                this.a = codedInputByteBufferNano.readString();
            } else if (tag == 18) {
                this.b = codedInputByteBufferNano.readString();
            } else if (tag == 26) {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 26);
                C0508p6[] c0508p6Arr = this.c;
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
                this.c = c0508p6Arr2;
            } else if (tag == 34) {
                if (this.d == null) {
                    this.d = new C0560r6();
                }
                codedInputByteBufferNano.readMessage(this.d);
            } else if (tag != 42) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength2 = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 42);
                C0560r6[] c0560r6Arr = this.e;
                int length2 = c0560r6Arr == null ? 0 : c0560r6Arr.length;
                int i2 = repeatedFieldArrayLength2 + length2;
                C0560r6[] c0560r6Arr2 = new C0560r6[i2];
                if (length2 != 0) {
                    System.arraycopy(c0560r6Arr, 0, c0560r6Arr2, 0, length2);
                }
                while (length2 < i2 - 1) {
                    C0560r6 c0560r6 = new C0560r6();
                    c0560r6Arr2[length2] = c0560r6;
                    codedInputByteBufferNano.readMessage(c0560r6);
                    codedInputByteBufferNano.readTag();
                    length2++;
                }
                C0560r6 c0560r7 = new C0560r6();
                c0560r6Arr2[length2] = c0560r7;
                codedInputByteBufferNano.readMessage(c0560r7);
                this.e = c0560r6Arr2;
            }
        }
        return this;
    }

    public static C0560r6 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0560r6().mergeFrom(codedInputByteBufferNano);
    }

    public static C0560r6 a(byte[] bArr) {
        return (C0560r6) MessageNano.mergeFrom(new C0560r6(), bArr);
    }
}
