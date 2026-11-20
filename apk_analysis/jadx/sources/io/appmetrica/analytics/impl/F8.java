package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class F8 extends MessageNano {
    public static volatile F8[] c;
    public C0666v8 a;
    public C0666v8[] b;

    public F8() {
        a();
    }

    public static F8[] b() {
        if (c == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (c == null) {
                        c = new F8[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return c;
    }

    public final F8 a() {
        this.a = null;
        this.b = C0666v8.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0666v8 c0666v8 = this.a;
        if (c0666v8 != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(1, c0666v8);
        }
        C0666v8[] c0666v8Arr = this.b;
        if (c0666v8Arr != null && c0666v8Arr.length > 0) {
            int i = 0;
            while (true) {
                C0666v8[] c0666v8Arr2 = this.b;
                if (i >= c0666v8Arr2.length) {
                    break;
                }
                C0666v8 c0666v9 = c0666v8Arr2[i];
                if (c0666v9 != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(2, c0666v9) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0666v8 c0666v8 = this.a;
        if (c0666v8 != null) {
            codedOutputByteBufferNano.writeMessage(1, c0666v8);
        }
        C0666v8[] c0666v8Arr = this.b;
        if (c0666v8Arr != null && c0666v8Arr.length > 0) {
            int i = 0;
            while (true) {
                C0666v8[] c0666v8Arr2 = this.b;
                if (i >= c0666v8Arr2.length) {
                    break;
                }
                C0666v8 c0666v9 = c0666v8Arr2[i];
                if (c0666v9 != null) {
                    codedOutputByteBufferNano.writeMessage(2, c0666v9);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final F8 mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                if (this.a == null) {
                    this.a = new C0666v8();
                }
                codedInputByteBufferNano.readMessage(this.a);
            } else if (tag != 18) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 18);
                C0666v8[] c0666v8Arr = this.b;
                int length = c0666v8Arr == null ? 0 : c0666v8Arr.length;
                int i = repeatedFieldArrayLength + length;
                C0666v8[] c0666v8Arr2 = new C0666v8[i];
                if (length != 0) {
                    System.arraycopy(c0666v8Arr, 0, c0666v8Arr2, 0, length);
                }
                while (length < i - 1) {
                    C0666v8 c0666v8 = new C0666v8();
                    c0666v8Arr2[length] = c0666v8;
                    codedInputByteBufferNano.readMessage(c0666v8);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0666v8 c0666v9 = new C0666v8();
                c0666v8Arr2[length] = c0666v9;
                codedInputByteBufferNano.readMessage(c0666v9);
                this.b = c0666v8Arr2;
            }
        }
        return this;
    }

    public static F8 b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new F8().mergeFrom(codedInputByteBufferNano);
    }

    public static F8 a(byte[] bArr) {
        return (F8) MessageNano.mergeFrom(new F8(), bArr);
    }
}
