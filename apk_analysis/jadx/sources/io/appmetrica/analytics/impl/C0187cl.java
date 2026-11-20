package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0187cl extends MessageNano {
    public static volatile C0187cl[] b;
    public C0213dl[] a;

    public C0187cl() {
        a();
    }

    public static C0187cl[] b() {
        if (b == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (b == null) {
                        b = new C0187cl[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return b;
    }

    public final C0187cl a() {
        this.a = C0213dl.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        C0213dl[] c0213dlArr = this.a;
        if (c0213dlArr != null && c0213dlArr.length > 0) {
            int i = 0;
            while (true) {
                C0213dl[] c0213dlArr2 = this.a;
                if (i >= c0213dlArr2.length) {
                    break;
                }
                C0213dl c0213dl = c0213dlArr2[i];
                if (c0213dl != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(1, c0213dl) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        C0213dl[] c0213dlArr = this.a;
        if (c0213dlArr != null && c0213dlArr.length > 0) {
            int i = 0;
            while (true) {
                C0213dl[] c0213dlArr2 = this.a;
                if (i >= c0213dlArr2.length) {
                    break;
                }
                C0213dl c0213dl = c0213dlArr2[i];
                if (c0213dl != null) {
                    codedOutputByteBufferNano.writeMessage(1, c0213dl);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0187cl mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
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
                C0213dl[] c0213dlArr = this.a;
                int length = c0213dlArr == null ? 0 : c0213dlArr.length;
                int i = repeatedFieldArrayLength + length;
                C0213dl[] c0213dlArr2 = new C0213dl[i];
                if (length != 0) {
                    System.arraycopy(c0213dlArr, 0, c0213dlArr2, 0, length);
                }
                while (length < i - 1) {
                    C0213dl c0213dl = new C0213dl();
                    c0213dlArr2[length] = c0213dl;
                    codedInputByteBufferNano.readMessage(c0213dl);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                C0213dl c0213dl2 = new C0213dl();
                c0213dlArr2[length] = c0213dl2;
                codedInputByteBufferNano.readMessage(c0213dl2);
                this.a = c0213dlArr2;
            }
        }
        return this;
    }

    public static C0187cl b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new C0187cl().mergeFrom(codedInputByteBufferNano);
    }

    public static C0187cl a(byte[] bArr) {
        return (C0187cl) MessageNano.mergeFrom(new C0187cl(), bArr);
    }
}
