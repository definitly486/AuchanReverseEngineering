package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0374k2 extends MessageNano {
    public static volatile C0374k2[] d;
    public C0348j2[] a;
    public C0323i2 b;
    public String[] c;

    public C0374k2() {
        a();
    }

    public static C0374k2[] b() {
        if (d == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (d == null) {
                        d = new C0374k2[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return d;
    }

    public final C0374k2 a() {
        this.a = C0348j2.b();
        this.b = null;
        this.c = WireFormatNano.EMPTY_STRING_ARRAY;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0348j2[] c0348j2Arr = this.a;
        int i = 0;
        if (c0348j2Arr != null && c0348j2Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0348j2[] c0348j2Arr2 = this.a;
                if (i2 >= c0348j2Arr2.length) {
                    break;
                }
                C0348j2 c0348j2 = c0348j2Arr2[i2];
                if (c0348j2 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(1, c0348j2) + iComputeSerializedSize;
                }
                i2++;
            }
        }
        C0323i2 c0323i2 = this.b;
        if (c0323i2 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(2, c0323i2);
        }
        String[] strArr = this.c;
        if (strArr == null || strArr.length <= 0) {
            return iComputeSerializedSize;
        }
        int iComputeStringSizeNoTag = 0;
        int i3 = 0;
        while (true) {
            String[] strArr2 = this.c;
            if (i >= strArr2.length) {
                return iComputeSerializedSize + iComputeStringSizeNoTag + i3;
            }
            String str = strArr2[i];
            if (str != null) {
                i3++;
                iComputeStringSizeNoTag = CodedOutputByteBufferNano.computeStringSizeNoTag(str) + iComputeStringSizeNoTag;
            }
            i++;
        }
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0348j2[] c0348j2Arr = this.a;
        int i = 0;
        if (c0348j2Arr != null && c0348j2Arr.length > 0) {
            int i2 = 0;
            while (true) {
                C0348j2[] c0348j2Arr2 = this.a;
                if (i2 >= c0348j2Arr2.length) {
                    break;
                }
                C0348j2 c0348j2 = c0348j2Arr2[i2];
                if (c0348j2 != null) {
                    codedOutputByteBufferNano.writeMessage(1, c0348j2);
                }
                i2++;
            }
        }
        C0323i2 c0323i2 = this.b;
        if (c0323i2 != null) {
            codedOutputByteBufferNano.writeMessage(2, c0323i2);
        }
        String[] strArr = this.c;
        if (strArr != null && strArr.length > 0) {
            while (true) {
                String[] strArr2 = this.c;
                if (i >= strArr2.length) {
                    break;
                }
                String str = strArr2[i];
                if (str != null) {
                    codedOutputByteBufferNano.writeString(3, str);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0374k2 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 10);
                C0348j2[] c0348j2Arr = this.a;
                int length = c0348j2Arr == null ? 0 : c0348j2Arr.length;
                int i = repeatedFieldArrayLength + length;
                C0348j2[] c0348j2Arr2 = new C0348j2[i];
                if (length != 0) {
                    System.arraycopy(c0348j2Arr, 0, c0348j2Arr2, 0, length);
                }
                while (length < i - 1) {
                    C0348j2 c0348j2 = new C0348j2();
                    c0348j2Arr2[length] = c0348j2;
                    codedInputByteBufferNano.readMessage(c0348j2);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0348j2 c0348j3 = new C0348j2();
                c0348j2Arr2[length] = c0348j3;
                codedInputByteBufferNano.readMessage(c0348j3);
                this.a = c0348j2Arr2;
            } else if (tag == 18) {
                if (this.b == null) {
                    this.b = new C0323i2();
                }
                codedInputByteBufferNano.readMessage(this.b);
            } else if (tag != 26) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength2 = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 26);
                String[] strArr = this.c;
                int length2 = strArr == null ? 0 : strArr.length;
                int i2 = repeatedFieldArrayLength2 + length2;
                String[] strArr2 = new String[i2];
                if (length2 != 0) {
                    System.arraycopy(strArr, 0, strArr2, 0, length2);
                }
                while (length2 < i2 - 1) {
                    strArr2[length2] = codedInputByteBufferNano.readString();
                    codedInputByteBufferNano.readTag();
                    length2++;
                }
                strArr2[length2] = codedInputByteBufferNano.readString();
                this.c = strArr2;
            }
        }
        return this;
    }

    public static C0374k2 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0374k2().mergeFrom(codedInputByteBufferNano);
    }

    public static C0374k2 a(byte[] bArr) {
        return (C0374k2) MessageNano.mergeFrom(new C0374k2(), bArr);
    }
}
