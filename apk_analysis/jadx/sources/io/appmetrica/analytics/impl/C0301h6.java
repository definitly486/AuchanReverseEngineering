package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0301h6 extends MessageNano {
    public static volatile C0301h6[] d;
    public C0535q6 a;
    public C0535q6[] b;
    public String c;

    public C0301h6() {
        a();
    }

    public static C0301h6[] b() {
        if (d == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (d == null) {
                        d = new C0301h6[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return d;
    }

    public final C0301h6 a() {
        this.a = null;
        this.b = C0535q6.b();
        this.c = "";
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0535q6 c0535q6 = this.a;
        if (c0535q6 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(1, c0535q6);
        }
        C0535q6[] c0535q6Arr = this.b;
        if (c0535q6Arr != null && c0535q6Arr.length > 0) {
            int i = 0;
            while (true) {
                C0535q6[] c0535q6Arr2 = this.b;
                if (i >= c0535q6Arr2.length) {
                    break;
                }
                C0535q6 c0535q7 = c0535q6Arr2[i];
                if (c0535q7 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(2, c0535q7) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return !this.c.equals("") ? CodedOutputByteBufferNano.computeStringSize(3, this.c) + iComputeSerializedSize : iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0535q6 c0535q6 = this.a;
        if (c0535q6 != null) {
            codedOutputByteBufferNano.writeMessage(1, c0535q6);
        }
        C0535q6[] c0535q6Arr = this.b;
        if (c0535q6Arr != null && c0535q6Arr.length > 0) {
            int i = 0;
            while (true) {
                C0535q6[] c0535q6Arr2 = this.b;
                if (i >= c0535q6Arr2.length) {
                    break;
                }
                C0535q6 c0535q7 = c0535q6Arr2[i];
                if (c0535q7 != null) {
                    codedOutputByteBufferNano.writeMessage(2, c0535q7);
                }
                i++;
            }
        }
        if (!this.c.equals("")) {
            codedOutputByteBufferNano.writeString(3, this.c);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0301h6 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                if (this.a == null) {
                    this.a = new C0535q6();
                }
                codedInputByteBufferNano.readMessage(this.a);
            } else if (tag == 18) {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 18);
                C0535q6[] c0535q6Arr = this.b;
                int length = c0535q6Arr == null ? 0 : c0535q6Arr.length;
                int i = repeatedFieldArrayLength + length;
                C0535q6[] c0535q6Arr2 = new C0535q6[i];
                if (length != 0) {
                    System.arraycopy(c0535q6Arr, 0, c0535q6Arr2, 0, length);
                }
                while (length < i - 1) {
                    C0535q6 c0535q6 = new C0535q6();
                    c0535q6Arr2[length] = c0535q6;
                    codedInputByteBufferNano.readMessage(c0535q6);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0535q6 c0535q7 = new C0535q6();
                c0535q6Arr2[length] = c0535q7;
                codedInputByteBufferNano.readMessage(c0535q7);
                this.b = c0535q6Arr2;
            } else if (tag != 26) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                this.c = codedInputByteBufferNano.readString();
            }
        }
        return this;
    }

    public static C0301h6 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0301h6().mergeFrom(codedInputByteBufferNano);
    }

    public static C0301h6 a(byte[] bArr) {
        return (C0301h6) MessageNano.mergeFrom(new C0301h6(), bArr);
    }
}
