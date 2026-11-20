package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Ao extends MessageNano {
    public static volatile Ao[] b;
    public C0734xo[] a;

    public Ao() {
        a();
    }

    public static Ao[] b() {
        if (b == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (b == null) {
                        b = new Ao[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return b;
    }

    public final Ao a() {
        this.a = C0734xo.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0734xo[] c0734xoArr = this.a;
        if (c0734xoArr != null && c0734xoArr.length > 0) {
            int i = 0;
            while (true) {
                C0734xo[] c0734xoArr2 = this.a;
                if (i >= c0734xoArr2.length) {
                    break;
                }
                C0734xo c0734xo = c0734xoArr2[i];
                if (c0734xo != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(1, c0734xo) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0734xo[] c0734xoArr = this.a;
        if (c0734xoArr != null && c0734xoArr.length > 0) {
            int i = 0;
            while (true) {
                C0734xo[] c0734xoArr2 = this.a;
                if (i >= c0734xoArr2.length) {
                    break;
                }
                C0734xo c0734xo = c0734xoArr2[i];
                if (c0734xo != null) {
                    codedOutputByteBufferNano.writeMessage(1, c0734xo);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Ao mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
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
                C0734xo[] c0734xoArr = this.a;
                int length = c0734xoArr == null ? 0 : c0734xoArr.length;
                int i = repeatedFieldArrayLength + length;
                C0734xo[] c0734xoArr2 = new C0734xo[i];
                if (length != 0) {
                    System.arraycopy(c0734xoArr, 0, c0734xoArr2, 0, length);
                }
                while (length < i - 1) {
                    C0734xo c0734xo = new C0734xo();
                    c0734xoArr2[length] = c0734xo;
                    codedInputByteBufferNano.readMessage(c0734xo);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0734xo c0734xo2 = new C0734xo();
                c0734xoArr2[length] = c0734xo2;
                codedInputByteBufferNano.readMessage(c0734xo2);
                this.a = c0734xoArr2;
            }
        }
        return this;
    }

    public static Ao b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new Ao().mergeFrom(codedInputByteBufferNano);
    }

    public static Ao a(byte[] bArr) {
        return (Ao) MessageNano.mergeFrom(new Ao(), bArr);
    }
}
