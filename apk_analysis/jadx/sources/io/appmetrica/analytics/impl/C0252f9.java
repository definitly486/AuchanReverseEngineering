package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.f9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0252f9 extends MessageNano {
    public static volatile C0252f9[] b;
    public C0226e9[] a;

    public C0252f9() {
        a();
    }

    public static C0252f9[] b() {
        if (b == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (b == null) {
                        b = new C0252f9[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return b;
    }

    public final C0252f9 a() {
        this.a = C0226e9.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0226e9[] c0226e9Arr = this.a;
        if (c0226e9Arr != null && c0226e9Arr.length > 0) {
            int i = 0;
            while (true) {
                C0226e9[] c0226e9Arr2 = this.a;
                if (i >= c0226e9Arr2.length) {
                    break;
                }
                C0226e9 c0226e9 = c0226e9Arr2[i];
                if (c0226e9 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(1, c0226e9) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0226e9[] c0226e9Arr = this.a;
        if (c0226e9Arr != null && c0226e9Arr.length > 0) {
            int i = 0;
            while (true) {
                C0226e9[] c0226e9Arr2 = this.a;
                if (i >= c0226e9Arr2.length) {
                    break;
                }
                C0226e9 c0226e9 = c0226e9Arr2[i];
                if (c0226e9 != null) {
                    codedOutputByteBufferNano.writeMessage(1, c0226e9);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0252f9 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
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
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 10);
                C0226e9[] c0226e9Arr = this.a;
                int length = c0226e9Arr == null ? 0 : c0226e9Arr.length;
                int i = repeatedFieldArrayLength + length;
                C0226e9[] c0226e9Arr2 = new C0226e9[i];
                if (length != 0) {
                    System.arraycopy(c0226e9Arr, 0, c0226e9Arr2, 0, length);
                }
                while (length < i - 1) {
                    C0226e9 c0226e9 = new C0226e9();
                    c0226e9Arr2[length] = c0226e9;
                    codedInputByteBufferNano.readMessage(c0226e9);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0226e9 c0226e10 = new C0226e9();
                c0226e9Arr2[length] = c0226e10;
                codedInputByteBufferNano.readMessage(c0226e10);
                this.a = c0226e9Arr2;
            }
        }
        return this;
    }

    public static C0252f9 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0252f9().mergeFrom(codedInputByteBufferNano);
    }

    public static C0252f9 a(byte[] bArr) {
        return (C0252f9) MessageNano.mergeFrom(new C0252f9(), bArr);
    }
}
